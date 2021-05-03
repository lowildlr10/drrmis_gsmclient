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