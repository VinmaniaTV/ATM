using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ATM
{

    class ApiAccess
    {
        public API_Obj Import(string _currency)
        {

                string URLString = "https://v6.exchangerate-api.com/v6/b84f1ffd6c865afbe54152f0/latest/"+ _currency;
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    JsonHelper js = new JsonHelper();
                    API_Obj Test = js.DeserializeAPI_Obj(json);
                    return Test;
                }
                
            }
        }
    }

   


