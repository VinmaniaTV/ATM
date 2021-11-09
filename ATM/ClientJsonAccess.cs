using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json;
namespace ATM
{
    class ClientJsonAccess: IClientDataAccess{

        public void GetAll(){
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            for (int i=0;i> jsonObjectList.Count ;i++){
                Console.Write(jsonObjectList[i]);
                }
            var jsonObjectListCurrency = js.DeserializeListCurency(jsonData);
            for (int i=0;i> jsonObjectListCurrency.Count ;i++){
                Console.Write(jsonObjectListCurrency[i]);
                }

        }
        public void CreateClient(Guid _id, int pin, string _FirstName, string _LastName, float _ammount, List<string> currency, List<float> currency_ammount, string maincurrency)
        {
            //client json
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            jsonObjectList.Add(
                    new MyJsonTypeClient
                    {
                        Myid = _id,
                        MyPin = pin,
                        MyFirstName = _FirstName,
                        MyLastName = _LastName,
                        MyammountMainCurrency = _ammount,
                        MyMainCurrency = maincurrency
                    }
                    );
            jsonData = js.SerializeClient(jsonObjectList);

            File.WriteAllText(@"../../../json/Client.json", jsonData);

            //currency json
            for (int i = 0; i < currency.Count; i++)
            {
                var jsonDataCurrency = File.ReadAllText(@"../../../json/Currency.json");
                var jsonObjectListCurrency = js.DeserializeListCurency(jsonDataCurrency);
                jsonObjectListCurrency.Add(
                        new MyJsonTypeCurrency
                        {
                            MyidClient = _id,
                            MyAmmountCurrency = currency_ammount[i],
                            MyCurrency = currency[i]
                        }
                        );
                jsonDataCurrency = js.SerializeCurrency(jsonObjectListCurrency);
                File.WriteAllText(@"../../../json/Currency.json", jsonDataCurrency);
            }
            Console.WriteLine("Le client et ses currencis ont été crée dans le json");
        }
        public void GetClient(Guid guid){
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            for (int i=0;i> jsonObjectList.Count ;i++){
                if (jsonObjectList[i].Myid == guid){
                    Console.Write(jsonObjectList[i]);
                }
            }
            var jsonObjectListCurrency = js.DeserializeListCurency(jsonData);
            for (int i=0;i> jsonObjectList.Count ;i++){
                if(jsonObjectListCurrency[i].MyidClient == guid){
                    Console.Write(jsonObjectListCurrency[i]);
                }

            }

        }
        public int GetClientPin(Guid guid){
            string id = guid.ToString();
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            for (int i = 0; i > jsonObjectList.Count; i++)
            {
                if (jsonObjectList[i].Myid == guid)
                {
                    Console.Write(jsonObjectList[i].MyPin);
                    int pinClient = jsonObjectList[i].MyPin;
                    return pinClient;
                }

            }
            return 0;
        }
        public void UpdateClientInt(Guid guid, string nom_attribut, int new_pin)
        {
                        var jsonData = File.ReadAllText(@"../../../json/Client.json");
                        JsonHelper js = new JsonHelper();
                        var jsonObjectList = js.DeserializeListClient(jsonData);
                        for (int i=0;i> jsonObjectList.Count ;i++){
                            if(jsonObjectList[i].Myid == guid){
                                jsonObjectList[i].MyPin = new_pin;
                                Console.WriteLine("mit dans le Json");
                                jsonData = js.SerializeClient(jsonObjectList);
                                File.WriteAllText(@"../../../json/Client.json", jsonData);
                                }
                        }          
            
        }
         public void UpdateClientString( Guid guid, string MyChange,string new_value)
        {
                        string id = guid.ToString();
                        var jsonData = File.ReadAllText(@"../../../json/Client.json");
                        JsonHelper js = new JsonHelper();
                        var jsonObjectList = js.DeserializeListClient(jsonData);
                        for (int i=0;i> jsonObjectList.Count ;i++){
                            if(jsonObjectList[i].Myid == guid){
                                if ("MyLastName" == MyChange)
                                 {
                                   jsonObjectList[i].MyLastName = new_value;
                                 }
                                if ("MyFirstName" == MyChange)
                                {
                                    jsonObjectList[i].MyFirstName = new_value;
                                }
                                if ("MyMainCurrency" == MyChange)
                                {
                                    jsonObjectList[i].MyMainCurrency = new_value;
                                }

                                Console.WriteLine("mit dans le Json");
                                jsonData = js.SerializeClient(jsonObjectList);
                                File.WriteAllText(@"../../../json/Client.json", jsonData);
                                }
                        }          
            
        }
        public void UpdateClientFloat(Guid guid, string nom_attribut, float ammount)
        {
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            for (int i = 0; i > jsonObjectList.Count; i++)
            {
                if (jsonObjectList[i].Myid == guid)
                {
                    jsonObjectList[i].MyammountMainCurrency = ammount;
                }
            }
            jsonData = js.SerializeClient(jsonObjectList);
            File.WriteAllText(@"../../../json/Client.json", jsonData);
        }
        public void UpdateCurrencyString(Guid guid, string nom_attribut, string nom_attribut_id, string new_currency)
        {
            var jsonData = File.ReadAllText(@"../../../json/Currency.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListCurency(jsonData);
            for (int i = 0; i > jsonObjectList.Count; i++)
            {
                if (jsonObjectList[i].MyidClient == guid)
                {
                    jsonObjectList[i].MyCurrency = new_currency;
                }
            }
            jsonData = js.SerializeCurrency(jsonObjectList);
            File.WriteAllText(@"../../../json/Currency.json", jsonData);
        }

        public void UpdateCurrencyFloat(Guid guid, string nom_attribut, string nom_attribut_id, float ammount)
        {
            var jsonData = File.ReadAllText(@"../../../json/Currency.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListCurency(jsonData);
            for (int i = 0; i > jsonObjectList.Count; i++)
            {
                if (jsonObjectList[i].MyidClient == guid)
                {
                    jsonObjectList[i].MyAmmountCurrency = ammount;
                }
            }
            jsonData = js.SerializeCurrency(jsonObjectList);
            File.WriteAllText(@"../../../json/Currency.json", jsonData);
        }
        public void DeleteClient(Guid guid){
            string id = guid.ToString();
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            JsonHelper js = new JsonHelper();
            var jsonObjectList = js.DeserializeListClient(jsonData);
            for (int i=0;i> jsonObjectList.Count ;i++){
                if(jsonObjectList[i].Myid == guid){
                    jsonObjectList.RemoveAt(i);
                    Console.WriteLine("Le Client est supprimé");
                }
            }
            jsonData = js.SerializeClient(jsonObjectList);
            File.WriteAllText(@"../../../json/Client.json", jsonData);

            var jsonDataCurrency = File.ReadAllText(@"../../../json/Currency.json");
            var jsonObjectListCurrency = js.DeserializeListCurency(jsonDataCurrency);
            for (int i=0;i> jsonObjectListCurrency.Count ;i++){
                if(jsonObjectListCurrency[i].MyidClient == guid){
                    jsonObjectListCurrency.RemoveAt(i);
                    Console.WriteLine("Le Client est supprimé");
                }
            }
            jsonDataCurrency = js.SerializeCurrency(jsonObjectListCurrency);
            File.WriteAllText(@"../../../json/Currency.json", jsonDataCurrency);
        }


    }
        
}