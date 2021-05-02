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
using System.Text.RegularExpressions;

namespace DRRMIS_GSM_Client
{
    internal class GsmModule {
        private static string baseURL = "http://drrmis.dostcar.ph";
        private static Dictionary<char, string[]> asciiCharsets = new Dictionary<char, string[]>() {
            {'@', new string[] {"01000000", "40"}},
            {'£', new string[] {"10100011", "A3"}},
            {'$', new string[] {"00100100", "24"}},
            {'¥', new string[] {"10100101", "A5"}},
            {'è', new string[] {"11101000", "E8"}},
            {'é', new string[] {"11101001", "E9"}},
            {'ù', new string[] {"11111001", "F9"}},
            {'ì', new string[] {"11101100", "EC"}},
            {'ò', new string[] {"11110010", "F2"}},
            {'Ç', new string[] {"11000111", "C7"}},
            {'\n', new string[] {"00001010", "0A"}},
            {'Ø', new string[] {"11011000", "D8"}},
            {'ø', new string[] {"11111000", "F8"}},
            {'\r', new string[] {"00001101", "0D"}},
            {'Å', new string[] {"11000101", "C5"}},
            {'å', new string[] {"11100101", "E5"}},
            {'_', new string[] {"01011111", "5F"}},
            {'Æ', new string[] {"11000110", "C6"}},
            {'æ', new string[] {"11100110", "E6"}},
            {'ß', new string[] {"11011111", "DF"}},
            {'É', new string[] {"11001001", "C9"}},
            {' ', new string[] {"00100000", "20"}},
            {'!', new string[] {"00100001", "21"}},
            {'"', new string[] {"00100010", "22"}},
            {'#', new string[] {"00100011", "23"}},
            {'¤', new string[] {"10100100", "A4"}},
            {'%', new string[] {"00100101", "25"}},
            {'&', new string[] {"00100110", "26"}},
            {'\'', new string[] {"00100111", "27"}}, 
            {'(', new string[] {"00101000", "28"}},
            {')', new string[] {"00101001", "29"}},
            {'*', new string[] {"00101010", "2A"}},
            {'+', new string[] {"00101011", "2B"}},
            {',', new string[] {"00101100", "2C"}},
            {'-', new string[] {"00101101", "2D"}},
            {'.', new string[] {"00101110", "2E"}},
            {'/', new string[] {"00101111", "2F"}},
            {'0', new string[] {"00110000", "30"}},
            {'1', new string[] {"00110001", "31"}},
            {'2', new string[] {"00110010", "32"}},
            {'3', new string[] {"00110011", "33"}},
            {'4', new string[] {"00110100", "34"}},
            {'5', new string[] {"00110101", "35"}},
            {'6', new string[] {"00110110", "36"}},
            {'7', new string[] {"00110111", "37"}},
            {'8', new string[] {"00111000", "38"}},
            {'9', new string[] {"00111001", "39"}},
            {':', new string[] {"00111010", "3A"}},
            {';', new string[] {"00111011", "3B"}},
            {'<', new string[] {"00111100", "3C"}},
            {'=', new string[] {"00111101", "3D"}},
            {'>', new string[] {"00111110", "3E"}},
            {'?', new string[] {"00111111", "3F"}},
            {'¡', new string[] {"10100001", "A1"}},
            {'A', new string[] {"01000001", "41"}},
            {'B', new string[] {"01000010", "42"}},
            {'C', new string[] {"01000011", "43"}},
            {'D', new string[] {"01000100", "44"}},
            {'E', new string[] {"01000101", "45"}},
            {'F', new string[] {"01000110", "46"}},
            {'G', new string[] {"01000111", "47"}},
            {'H', new string[] {"01001000", "48"}},
            {'I', new string[] {"01001001", "49"}},
            {'J', new string[] {"01001010", "4A"}},
            {'K', new string[] {"01001011", "4B"}},
            {'L', new string[] {"01001100", "4C"}},
            {'M', new string[] {"01001101", "4D"}},
            {'N', new string[] {"01001110", "4E"}},
            {'O', new string[] {"01001111", "4F"}},
            {'P', new string[] {"01010000", "50"}},
            {'Q', new string[] {"01010001", "51"}},
            {'R', new string[] {"01010010", "52"}},
            {'S', new string[] {"01010011", "53"}},
            {'T', new string[] {"01010100", "54"}},
            {'U', new string[] {"01010101", "55"}},
            {'V', new string[] {"01010110", "56"}},
            {'W', new string[] {"01010111", "57"}},
            {'X', new string[] {"01011000", "58"}},
            {'Y', new string[] {"01011001", "59"}},
            {'Z', new string[] {"01011010", "5A"}},
            {'Ä', new string[] {"11000100", "C4"}},
            {'Ö', new string[] {"11010110", "D6"}},
            {'Ñ', new string[] {"11010001", "D1"}},
            {'Ü', new string[] {"11011100", "DC"}},
            {'§', new string[] {"10100111", "A7"}},
            {'¿', new string[] {"10111111", "BF"}},
            {'a', new string[] {"01100001", "61"}},
            {'b', new string[] {"01100010", "62"}},
            {'c', new string[] {"01100011", "63"}},
            {'d', new string[] {"01100100", "64"}},
            {'e', new string[] {"01100101", "65"}},
            {'f', new string[] {"01100110", "66"}},
            {'g', new string[] {"01100111", "67"}},
            {'h', new string[] {"01101000", "68"}},
            {'i', new string[] {"01101001", "69"}},
            {'j', new string[] {"01101010", "6A"}},
            {'k', new string[] {"01101011", "6B"}},
            {'l', new string[] {"01101100", "6C"}},
            {'m', new string[] {"01101101", "6D"}},
            {'n', new string[] {"01101110", "6E"}},
            {'o', new string[] {"01101111", "6F"}},
            {'p', new string[] {"01110000", "70"}},
            {'q', new string[] {"01110001", "71"}},
            {'r', new string[] {"01110010", "72"}},
            {'s', new string[] {"01110011", "73"}},
            {'t', new string[] {"01110100", "74"}},
            {'u', new string[] {"01110101", "75"}},
            {'v', new string[] {"01110110", "76"}},
            {'w', new string[] {"01110111", "77"}},
            {'x', new string[] {"01111000", "78"}},
            {'y', new string[] {"01111001", "79"}},
            {'z', new string[] {"01111010", "7A"}},
            {'ä', new string[] {"11100100", "E4"}},
            {'ö', new string[] {"11110110", "F6"}},
            {'ñ', new string[] {"11110001", "F1"}},
            {'ü', new string[] {"11111100", "FC"}},
            {'à', new string[] {"11100000", "E0"}},
        };

        public GsmModule() { }

        public string BaseUrl {
            get { return baseURL; }
            set { baseURL = value; }
        }

        public string GetEncodedChar(char charVal) {
            string encoded = asciiCharsets[charVal][1];

            return encoded;
        }

        public string GetEncodedString(string stringVal) {
            string encoded = "";

            foreach (char charVal in stringVal.ToCharArray()) {
                encoded += GetEncodedChar(charVal);
            }

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

        public async Task<string[]> ChunkTextMsgs(string textMsg) {
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

                            msgChunk = $"({ctrMsgChunk}/{msgChunkCount}) " +
                                           textMsg.Substring(indexSubstring, lengthSubstring);

                            msgChunks.Add(msgChunk);
                        }
                    } else {
                        msgChunks.Add(textMsg);
                    }
                }
            });

            return msgChunks.ToArray();
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
                string msgBody = EncodeToGSM7(message);
                string ud = udhLength + udh + msgBody;
                string udLength = (((ud.Length / 2) * 8) / 7).ToString("X2");

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