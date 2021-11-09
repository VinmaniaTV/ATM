using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json;
namespace ATM
{
    class JsonHelper{
        public List<MyJsonTypeClient> DeserializeListClient(string jsonData){
            var jsonObjectList = JsonConvert.DeserializeObject<List<MyJsonTypeClient>>(jsonData);
            return jsonObjectList;
        }
        public List<MyJsonTypeCurrency> DeserializeListCurency(string jsonData){
            var jsonObjectList = JsonConvert.DeserializeObject<List<MyJsonTypeCurrency>>(jsonData);
            return jsonObjectList;
        }
        public API_Obj DeserializeAPI_Obj(string jsonData){
            var jsonObjectList = JsonConvert.DeserializeObject<API_Obj>(jsonData);
            return jsonObjectList;
        }
        public string SerializeClient(List<MyJsonTypeClient> jsonData){
            string jsonObjectList = JsonConvert.SerializeObject(jsonData,Formatting.Indented);
            return jsonObjectList;
        }
        public string SerializeCurrency(List<MyJsonTypeCurrency> jsonData){
            var jsonObjectList = JsonConvert.SerializeObject(jsonData,Formatting.Indented);
            return jsonObjectList;
        }


    }
}