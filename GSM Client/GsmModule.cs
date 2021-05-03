using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace DRRMIS_GSM_Client
{
    internal class GsmModule {
        private static string baseURL = "http://drrmis.dostcar.ph";

        public GsmModule() { }

        public string BaseUrl {
            get { return baseURL; }
            set { baseURL = value; }
        }

        public string GetEncodedChar(char charVal) {
            string encoded = asciiCharsets[charVal][1];

            return encoded;
        }

        public string GetPairInvertPhoneNumber(string phoneNo) {
            phoneNo = "63" + phoneNo.Substring(1);
            int phoneNoCount = phoneNo.Length;
            string newPhoneNo = "";
            
            if (phoneNoCount % 2 != 0) {
                phoneNo = phoneNo + "F";
            }

            char[] phoneNoChar = phoneNo.ToCharArray();

            for (int x = 0; x < phoneNoCount; x = x + 2) {
                newPhoneNo += phoneNoChar[x + 1].ToString() + phoneNoChar[x];
            }

            return newPhoneNo;
        }

        public string FormatPhoneNumber(string phoneNo) {
            string formatedPhoneNo = Regex.Replace(phoneNo, "/[^+0-9]/", "");
            int digitCount = formatedPhoneNo.Length;
            bool isValidNumber = false;

            if (digitCount < 10 && digitCount > 13) {
                return "not-valid";
            }

            if (digitCount <= 0) {
                return "not-valid";
            }

            if (formatedPhoneNo.Substring(0, 1) == "9" && digitCount == 10) {
                formatedPhoneNo = "0" + formatedPhoneNo;
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 2) == "09" && digitCount == 11) {
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 3) == "639" && digitCount == 12) {
                formatedPhoneNo = "+" + formatedPhoneNo;
                formatedPhoneNo = formatedPhoneNo.Replace("+63", "0");
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 4) == "+639" && digitCount == 13) {
                formatedPhoneNo = formatedPhoneNo.Replace("+63", "0");
                isValidNumber = true;
            }

            if (!isValidNumber) {
                return "not-valid";
            }

            return formatedPhoneNo;
        }

        public async Task<string[]> ChunkTextMsgs(string messageMode, string textMsg) {
            var msgChunks = new List<string>();
            int msgCount = textMsg.Length;

            await Task.Run(() => {
                if (msgCount <= 160) {
                    msgChunks.Add(textMsg);
                } else {
                    int msgCountDivisor = 153;
                    int msgChunkCount = (msgCount / msgCountDivisor) + 1;

                    if (msgChunkCount > 1) {
                        for (int ctrMsgChunk = 1; ctrMsgChunk <= msgChunkCount; ctrMsgChunk++) {
                            int indexSubstring = (ctrMsgChunk - 1) * msgCountDivisor;
                            int lengthSubstring = msgCountDivisor;
                            string msgChunk = "";

                            if (ctrMsgChunk == 1) {
                            } else if (ctrMsgChunk > 1 && ctrMsgChunk < msgChunkCount) {
                            } else {
                                lengthSubstring = msgCount - ((ctrMsgChunk - 1) * msgCountDivisor);
                            }

                            if (messageMode == "Text") {
                                msgChunk = $"({ctrMsgChunk}/{msgChunkCount}) " +
                                           textMsg.Substring(indexSubstring, lengthSubstring);
                            } else {
                                msgChunk = textMsg.Substring(indexSubstring, lengthSubstring);
                            }

                            msgChunks.Add(msgChunk);
                        }
                    } else {
                        msgChunks.Add(textMsg);
                    }
                }
            });

            return msgChunks.ToArray();
        }

        public string EncodedToAscii(string message) {
            string encoded = "";

            foreach (char msgChar in message.ToCharArray()) {
                encoded += GetEncodedChar(msgChar);
            }

            return encoded;
        }

        public string EncodeToGSM7(string message) {
            char[] messageCharacters = message.ToCharArray();
            List<string> charOctets = new List<string>();
            List<string> charSeptets = new List<string>();
            List<string> charNewOctets = new List<string>();
            string encodedHex = "";

            int bitCounter = 1;

            // Get hex binary value
            foreach (char msgChar in messageCharacters) {
                charOctets.Add(asciiCharsets[msgChar][0]);
            }

            // Take the most signficant bit
            foreach (string charOct in charOctets) {
                charSeptets.Add(charOct.Substring(1));
            }

            charOctets.Clear();

            // Form a new octet
            for (int septCtr = 1; septCtr < charSeptets.Count; septCtr++) {
                if (!string.IsNullOrEmpty(charSeptets[septCtr - 1].Trim())) {
                    string septetSegment = charSeptets[septCtr].Substring(7 - bitCounter);
                    charSeptets[septCtr] = charSeptets[septCtr].Substring(0, 7 - bitCounter);
                    charSeptets[septCtr - 1] = septetSegment + charSeptets[septCtr - 1];
                    charNewOctets.Add(charSeptets[septCtr - 1]);
                    bitCounter++;
                } else {
                    bitCounter = 1;
                }

                if (charSeptets.Count == septCtr + 1) {
                    int lastSeptIndex = charSeptets.Count - 1;
                    int lastSeptLength = charSeptets[lastSeptIndex].Length;
                    int zeroToAddCount = 8 - lastSeptLength;

                    for (int zeroCtr = 1; zeroCtr <= zeroToAddCount; zeroCtr++) {
                        charSeptets[lastSeptIndex] = "0" + charSeptets[lastSeptIndex];
                    }

                    charNewOctets.Add(charSeptets[lastSeptIndex]);
                }
            }

            charSeptets.Clear();

            // Get the new octet hex value
            foreach (string charNewOctet in charNewOctets) {
                encodedHex += Convert.ToInt32(charNewOctet, 2).ToString("X2");
            }

            charNewOctets.Clear();

            return encodedHex;
        }

        public string EncodeToPaddingZeroBit(string encodedHex) {
            List<string> hexValues = new List<string>();
            List<string> binaryValue = new List<string>();
            encodedHex = Regex.Replace(encodedHex, @"\s+", "");
            char[] hexCharacters = encodedHex.ToCharArray();
            int hexCharCount = hexCharacters.Length;
            string paddedBinaries = "";
            string paddedHex = "";

            if (hexCharCount % 2 == 0) {
                string tempBinary = "";

                // Store hex values
                for (int hexCtr = 0; hexCtr < hexCharCount - 1; hexCtr = hexCtr + 2) {
                    hexValues.Add(hexCharacters[hexCtr].ToString() + hexCharacters[hexCtr + 1].ToString());
                }

                // Convert hex to binary and store
                foreach (string hex in hexValues) {
                    char[] binChars = Convert.ToString(Convert.ToInt32(hex.ToString(), 16), 2).PadLeft(8, '0').ToCharArray();
                    Array.Reverse(binChars);
                    paddedBinaries += new string(binChars);
                }

                hexValues.Clear();

                paddedBinaries = "0" + paddedBinaries.Substring(0, paddedBinaries.Length - 1);

                foreach (char binChar in paddedBinaries.ToCharArray()) {
                    tempBinary += binChar.ToString();

                    if (tempBinary.Length == 8) {
                        char[] bin = tempBinary.ToCharArray();
                        Array.Reverse(bin);
                        paddedHex += Convert.ToInt32(new string(bin), 2).ToString("X2");

                        tempBinary = "";
                    }
                }
            } else {
                return "error";
            }

            return paddedHex;
        }

        public Dictionary<string, string> GetEncodedMsgPDU(
            string phoneNo, string message, int msgChunkCount, int msgChunkCtr) {
            Dictionary<string, string> encodedPDU = new Dictionary<string, string>();
            string totalMsgLength = "";
            string encodedStrPDU = "";

            string smsc = "00";
            string typePDU = "01";
            string msgRefNumber = "00";
            string destType = "91";
            string destPhoneNo = GetPairInvertPhoneNumber(phoneNo);
            string destLength = destPhoneNo.Length.ToString("X2");
            string protocolId = "00";
            string dataCodingSch = "00";

            if (msgChunkCount > 1) {
                /*
                 * 1 - SMSC
                 * 2 - Type of the TPDU
                 * 3 - Message Reference Number
                 * 4 - Length of the Destination Phone Number
                 * 5 - Type of the Destination Phone Number (0x81: Local; 0x91: International;)
                 * 6 - Destination Phone Number
                 * 7 - Protocol Identifier
                 * 8 - Data Coding Scheme
                 * 9 - UDL (User-Data-Length)
                 * 10 - UDHL (User data header length)
                 * 11 - IE Concatenated message IE
                 * 12 - 10 - SMS Message Body
                */

                string udhLength = "05";
                string udh = "000300030" + msgChunkCtr;
                string msgBody = EncodeToPaddingZeroBit(EncodeToGSM7(message));
                string ud = udhLength + udh + msgBody;
                string udLength = (((ud.Length) * 4) / 7).ToString("X2");

                typePDU = "41";
                encodedStrPDU = smsc + typePDU + msgRefNumber + destLength + destType +
                                destPhoneNo + protocolId + dataCodingSch + udLength + ud;
                totalMsgLength = ((encodedStrPDU.Length / 2) - 1).ToString();
            } else {
                /*
                 * 1 - SMSC
                 * 2 - Type of the TPDU
                 * 3 - Message Reference Number
                 * 4 - Length of the Destination Phone Number
                 * 5 - Type of the Destination Phone Number (0x81: Local; 0x91: International;)
                 * 6 - Destination Phone Number
                 * 7 - Protocol Identifier
                 * 8 - Data Coding Scheme
                 * 9 - Length of the SMS Message Body
                 * 10 - SMS Message Body
                */

                string msgBody = EncodeToGSM7(message);
                string lengthMsgBody = (message.Length).ToString("X2");
                encodedStrPDU = smsc + typePDU + msgRefNumber + destLength + destType + 
                                destPhoneNo + protocolId + dataCodingSch + lengthMsgBody +
                                msgBody;
                totalMsgLength = ((encodedStrPDU.Length / 2) - 1).ToString();
            }

            encodedPDU.Add("total_msg_length", totalMsgLength);
            encodedPDU.Add("encoded_pdu_msg", encodedStrPDU);

            return encodedPDU;
        }

        public async Task<string> GetQueueMessages(string token) {
            string result;
            string apiURL = baseURL + "/api/get-queue-sms";
            Uri url = new Uri(apiURL);

            JsonProcessor jsonProc = new JsonProcessor();
            var _data = new {
                token = token
            };
            StringContent data = jsonProc.ParseJson(_data);

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                result = "error-connection";
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            bool isSuccess = json.ContainsKey("success");

            if (isSuccess) {
                result = json["success"].ToString();
            } else {
                result = "error-connection";
            }

            return result;
        }

        public async Task<string> DisposeSentMessages(string token, string filename) {
            string result;
            string apiURL = baseURL + "/api/dispose-sent-msgs";
            Uri url = new Uri(apiURL);

            JsonProcessor jsonProc = new JsonProcessor();
            var _data = new {
                token = token,
                filename = filename
            };
            StringContent data = jsonProc.ParseJson(_data);

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                result = "error-connection";
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            bool isSuccess = json.ContainsKey("success");

            if (isSuccess) {
                result = "no-error";
            } else {
                result = "error-connection";
            }

            return result;
        }

        public async Task<string> StoreSentMessages(string token, List<string> logs, string message) {
            string result;
            string messageLogs = string.Join(",", logs);
            string apiURL = baseURL + "/api/store-sent-msgs";
            Uri url = new Uri(apiURL);

            JsonProcessor jsonProc = new JsonProcessor();
            var _data = new {
                token = token,
                message_logs = messageLogs,
                message = message
            };
            StringContent data = jsonProc.ParseJson(_data);

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                result = "error-connection";
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            bool isSuccess = json.ContainsKey("success");

            if (isSuccess) {
                result = "no-error";
            } else {
                result = "error-connection";
            }

            return result;
        }
    }
}