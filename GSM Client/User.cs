using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace DRRMIS_GSM_Client
{
    public class User {
        private static string baseURL = "http://drrmis.dostcar.ph";
        private static int userID;
        private static string firstname;
        private static string lastname;
        private static string username;
        private static string token;
        private static bool hasError = true;

        public User() { }

        public int Id {
            get { return userID; }
            set { userID = value; }
        }

        public string Firstname {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Username {
            get { return username; }
            set { username = value; }
        }

        public string Token {
            get { return token; }
            set { token = value; }
        }

        public string BaseUrl {
            get { return baseURL; }
            set { baseURL = value; }
        }

        public bool HasError {
            get { return hasError; }
            set { hasError = value; }
        }

        public async Task<string> Login(string username, string password) {
            string result;
            string apiURL = baseURL + "/api/login";
            Uri url = new Uri(apiURL);

            JsonProcessor jsonProc = new JsonProcessor();
            var _data = new {
                login = username,
                password = password
            };
            StringContent data = jsonProc.ParseJson(_data);

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var authCredentials = System.Text.Encoding.ASCII.GetBytes($"{ username }:{password}");
                    string encodedAuth = System.Convert.ToBase64String(authCredentials);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuth);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                return "error-connection";
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            bool isSuccess = json.ContainsKey("success");

            if (isSuccess) {
                string successVal = json["success"].ToString();
                var jsonSuccess = JsonConvert.DeserializeObject<Dictionary<string, object>>(successVal);
                string token = jsonSuccess["token"].ToString();

                string userResult = await GetInformation(token);

                if (userResult != "error-connection") {
                    var jsonUser = JsonConvert.DeserializeObject<Dictionary<string, object>>(userResult);
                    bool isUserSuccess = jsonUser.ContainsKey("success");

                    this.Token = token;

                    if (isUserSuccess) {
                        successVal = jsonUser["success"].ToString();
                        jsonSuccess = JsonConvert.DeserializeObject<Dictionary<string, object>>(successVal);

                        int usrID = int.Parse(jsonSuccess["id"].ToString());
                        string usrFirstname = jsonSuccess["first_name"].ToString();
                        string usrLastname = jsonSuccess["last_name"].ToString();
                        string usrUsername = jsonSuccess["username"].ToString();

                        this.Id = usrID;
                        this.Firstname = usrFirstname;
                        this.Lastname = usrLastname;
                        this.Username = usrUsername;
                        this.HasError = false;
                    } else {
                        return "error-credentials";
                    }
                } else {
                    return "error-connection";
                }
            } else {
                return "error-credentials";
            }

            return "no-error";
        }

        public async Task<string> Logout() {
            string result;
            string apiURL = baseURL + "/api/logout/" + userID;
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
                return "error-connection";
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            bool isSuccess = json.ContainsKey("success");

            return isSuccess ? "no-error" : "error-connection";
        }

        public async Task<string> GetInformation(string token) {
            string result;
            string apiURL = baseURL + "/api/user-info";
            Uri url = new Uri(apiURL);

            JsonProcessor jsonProc = new JsonProcessor();
            var _data = new {
                token = token
            };
            StringContent data = jsonProc.ParseJson(_data);

            try {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                result = "error-connection";
            }

            return result;
        }

        
    }
}
