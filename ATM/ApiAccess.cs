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
        public List<float> AmmountCurrencies(string main_currency,List<string> name )
        {
            API_Obj Test = Import(main_currency);
            List<float> list = new List<float>();
            for (int i = 0; i < name.Count; i++)
            {
                if(name[i] == "AED")
                {
                    list.Add((float)Test.conversion_rates.AED);
                }

                if (name[i] == "ARS")
                {
                    list.Add((float)Test.conversion_rates.ARS);
                }
                if (name[i] == "AUD")
                {
                    list.Add((float)Test.conversion_rates.AUD);
                }

                if (name[i] == "BGN")
                {
                    list.Add((float)Test.conversion_rates.BGN);
                }
                if (name[i] == "BRL")
                {
                    list.Add((float)Test.conversion_rates.BRL);
                }

                if (name[i] == "BSD")
                {
                    list.Add((float)Test.conversion_rates.BSD) ;
                }
                if (name[i] == "CAD")
                {
                    list.Add((float)Test.conversion_rates.CAD);
                }

                if (name[i] == "CHF")
                {
                    list.Add((float)Test.conversion_rates.CHF);
                }
                if (name[i] == "CLP")
                {
                    list.Add((float)Test.conversion_rates.CLP);
                }

                if (name[i] == "CNY")
                {
                    list.Add((float)Test.conversion_rates.CNY);
                }
                if (name[i] == "COP")
                {
                    list.Add((float)Test.conversion_rates.COP);
                }

                if (name[i] == "CZK")
                {
                    list.Add((float)Test.conversion_rates.CZK);
                }
                if (name[i] == "DKK")
                {
                    list.Add((float)Test.conversion_rates.DKK);
                }

                if (name[i] == "DOP")
                {
                    list.Add((float)Test.conversion_rates.DOP);
                }
                if (name[i] == "EGP")
                {
                    list.Add((float)Test.conversion_rates.EGP);
                }

                if (name[i] == "EUR")
                {
                    list.Add((float)Test.conversion_rates.EUR);
                }
                if (name[i] == "FJD")
                {
                    list.Add((float)Test.conversion_rates.FJD);
                }

                if (name[i] == "GBP")
                {
                    list.Add((float)Test.conversion_rates.GBP);
                }
                if (name[i] == "GTQ")
                {
                    list.Add((float)Test.conversion_rates.GTQ);
                }

                if (name[i] == "HKD")
                {
                    list.Add((float)Test.conversion_rates.HKD);
                }
                if (name[i] == "HRK")
                {
                    list.Add((float)Test.conversion_rates.HRK);
                }

                if (name[i] == "HUF")
                {
                    list.Add((float)Test.conversion_rates.HUF);
                }
                if (name[i] == "IDR")
                {
                    list.Add((float)Test.conversion_rates.IDR);
                }

                if (name[i] == "ILS")
                {
                    list.Add((float)Test.conversion_rates.ILS);
                }
                if (name[i] == "INR")
                {
                    list.Add((float)Test.conversion_rates.INR);
                }

                if (name[i] == "ISK")
                {
                    list.Add((float)Test.conversion_rates.ISK);
                }
                if (name[i] == "JPY")
                {
                    list.Add((float)Test.conversion_rates.JPY);
                }

                if (name[i] == "ZAR")
                {
                    list.Add((float)Test.conversion_rates.ZAR);
                }
                if (name[i] == "UYU")
                {
                    list.Add((float)Test.conversion_rates.UYU);
                }
                if (name[i] == "USD")
                {
                    list.Add((float)Test.conversion_rates.USD);
                }
                if (name[i] == "UAH")
                {
                    list.Add((float)Test.conversion_rates.UAH);
                }
                if (name[i] == "TWD")
                {
                    list.Add((float)Test.conversion_rates.TWD);
                }
                if (name[i] == "TRY")
                {
                    list.Add((float)Test.conversion_rates.TRY);
                }
                if (name[i] == "THB")
                {
                    list.Add((float)Test.conversion_rates.THB);
                }
                if (name[i] == "SGD")
                {
                    list.Add((float)Test.conversion_rates.SGD);
                }
                if (name[i] == "SEK")
                {
                    list.Add((float)Test.conversion_rates.SEK);
                }
                if (name[i] == "SAR")
                {
                    list.Add((float)Test.conversion_rates.SAR);
                }
                if (name[i] == "RUB")
                {
                    list.Add((float)Test.conversion_rates.RUB);
                }
                if (name[i] == "RON")
                {
                    list.Add((float)Test.conversion_rates.RON);
                }
                if (name[i] == "PYG")
                {
                    list.Add((float)Test.conversion_rates.PYG);
                }
                if (name[i] == "PLN")
                {
                    list.Add((float)Test.conversion_rates.PLN);
                }
                if (name[i] == "PKR")
                {
                    list.Add((float)Test.conversion_rates.PKR);
                }
                if (name[i] == "PHP")
                {
                    list.Add((float)Test.conversion_rates.PHP);
                }
                if (name[i] == "PEN")
                {
                    list.Add((float)Test.conversion_rates.PEN);
                }
                if (name[i] == "PAB")
                {
                    list.Add((float)Test.conversion_rates.PAB);
                }
                if (name[i] == "NZD")
                {
                    list.Add((float)Test.conversion_rates.NZD);
                }
                if (name[i] == "NOK")
                {
                    list.Add((float)Test.conversion_rates.NOK);
                }
                if (name[i] == "MYR")
                {
                    list.Add((float)Test.conversion_rates.MYR);
                }
                if (name[i] == "MXN")
                {
                    list.Add((float)Test.conversion_rates.MXN);
                }
                if (name[i] == "KZT")
                {
                    list.Add((float)Test.conversion_rates.KZT);
                }
                if (name[i] == "KRW")
                {
                    list.Add((float)Test.conversion_rates.KRW);
                }

            }

            return list;
        }
        }
    }

   


