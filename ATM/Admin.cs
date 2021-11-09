using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;



namespace ATM
{
    class Admin : ClassDBAccess
    {
        private string username;
        private string password;
        public string Username { get { return username; } set { username = value; } }
        private string Password { get { return password; } set { password = value; } }
        public Admin(string _username, string _password)
        {
            this.Username = _username;
            this.Password = _password;
        }
        public Client createClient(Guid _id, int _pin, string _FirstName, string _LastName, float _ammount, List<string> currency, string maincurrency)
        {
            //api
            ApiAccess apiAccess = new ApiAccess();
            List<float> currency_ammount = apiAccess.AmmountCurrencies(maincurrency, currency);
            
            Client c = new Client(_id, _pin,  _FirstName, _LastName, _ammount, currency,currency_ammount, maincurrency);          
            //json
            ClientJsonAccess js = new ClientJsonAccess();
            js.CreateClient(c.Id, _pin, c.FirstName, c.LastName, c.AmmountMainCurrency, c.CurrencyName, c.Currency_ammount, c.Maincurrency);
            // à faire avec la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.CreateClient(c.Id,_pin,c.FirstName,c.LastName,c.AmmountMainCurrency,c.CurrencyName,c.Currency_ammount,c.Maincurrency); ;
            c.Tries= 0;
            c.IsCardBlocked = false;
            c.IsLoggedIn = false;
            Console.WriteLine("Le client a été crée");
            return c;
        }

        public void unblockClient(Client client)
        {
            client.IsCardBlocked = false;

        }

        public void blockClient(Client client)
        {
            client.IsCardBlocked = true;
        }

        public void changePin(Client client, int new_pin)
        {
            client.ChangePin(new_pin);
        }

        public void resetTries(Client client)
        {
            client.Tries = 0;
        }

        public void deleteClient(Client client)
        {
            //effacer dans json
            ClientJsonAccess js = new ClientJsonAccess();
            js.DeleteClient(client.Id);
            // effacer dans la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.DeleteClient(client.Id);
            Console.WriteLine("The client has been deleted");
        }

        public void GetAllClient()
        {
            // affiche liste des clients dans le json
            ClientJsonAccess js = new ClientJsonAccess();
            js.GetAll();
            // affiche liste des clients dans la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.GetAll();
        }
        public void GetClient(Guid c)
        {
            // affiche les informations client du fichier json
            ClientJsonAccess js = new ClientJsonAccess();
            js.GetClient(c);
            // affiche les informations client de la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.GetClient(c);
        }

    }
}