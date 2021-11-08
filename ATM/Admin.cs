using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropService;
using System.Runtime.dll;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ATM
{
    class Admin
    {
        private string username;
        private string password;
        public string Username { get { return username; } set { username = value; } }
        private string Password { get { return password; } set { password = value; } }
        private void admin(string _username, string _password)
        {
            this.Username = _username;
            this.Password = _password;
        }
        private void createClient (Guid _id, int _pin, int _ammount, string _firstName, string _LastName, string _mainCurrency, int _ammountMainAccount, List<String> _currency,List<float> _ammountCurrency)
        {
            Client client = new Client(_id, _pin, _ammount);
            //client json
            var jsonData = File.ReadAllText(@"../../../json/Client.json");
            var jsonObjectList = JsonConvert.DeserializeObject<List<MyJsonTypeClient>>(jsonData);
            jsonObjectList.Add(
                    new MyJsonTypeClient
                    {
                            Myid=_id,
                            MyPin= _pin,
                            MyFirstName= _firstName,
                            MyLastName= _LastName,
                            MyammountMainCurrency= _ammount,
                            MyMainCurrency= _mainCurrency
                    }
                    );
            jsonData = JsonConvert.SerializeObject(jsonObjectList, Formatting.Indented);

            File.WriteAllText(@"../../../json/Client.json", jsonData);

            //currency json
            for (int i = 0; i < _currency.Count; i++)
            {
                var jsonDataCurrency = File.ReadAllText(@"../../../json/Client.json");
                var jsonObjectListCurrency = JsonConvert.DeserializeObject<List<MyJsonTypeCurrency>>(jsonDataCurrency);
                jsonObjectListCurrency.Add(
                        new MyJsonTypeCurrency
                        {
                            MyidClient = _id,
                            MyAmmountCurrency = _ammountCurrency.ElementAt(i) ,
                            MyCurrency = _currency.ElementAt(i)
                        }
                        );
                jsonData = JsonConvert.SerializeObject(jsonObjectList, Formatting.Indented);
            }
            // à faire avec la base de données
            Console.WriteLine("Le client a été crée");
        }

        private void unblockClient(Client client)
        {
            client.isBlocked = false;
            // à faire avec la base de données
        }

        private void blockClient(Client client)
        {
            client.isBlocked = true;
            // à faire avec la base de données
        }

        private void changePin(Client client)
        {
            client._pin = true;
            // à faire avec la base de données
        }

        private void resetTries(Client client)
        {
            client.tries = 0;
            // à faire avec la base de données
        }

        private void deleteClient(Client client)
        {
           // à faire avec la base de données
        }

        private void listeClient()
        {
            // à faire avec la base de données
        }

    }