using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ATM
{

    class Rates
    {
        public bool Import(string _currency)
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/b84f1ffd6c865afbe54152f0/latest/"+ _currency;
                Console.WriteLine(URLString);
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    API_Obj Test = JsonConvert.DeserializeObject<API_Obj>(json);
                    ConversionRate re = Test.conversion_rates;
                    Console.WriteLine(re);
                    Console.WriteLine(re);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

   

}
