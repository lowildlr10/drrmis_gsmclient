using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DRRMIS_GSM_Client
{
    class JsonProcessor {

        public JsonProcessor() {

        }

        public StringContent ParseJson(object jsonObj) {
            string json = JsonConvert.SerializeObject(jsonObj);
            StringContent data = new StringContent(
                json, Encoding.UTF8, "application/json"
            );

            return data;
        }
    }
}
