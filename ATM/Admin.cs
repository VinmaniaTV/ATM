using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ATM
{
    class Admin : ClassDBAccess
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
        private void createClient(Client c,int pin)
        {
            //json
            ClientJsonAccess js = new ClientJsonAccess();
            js.CreateClient(c.Id, pin, c.FirstName, c.LastName, c.AmmountMainCurrency, c.CurrencyName, c.Currency_ammount, c.Maincurrency);
            // à faire avec la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.CreateClient(c.Id,pin,c.FirstName,c.LastName,c.AmmountMainCurrency,c.CurrencyName,c.Currency_ammount,c.Maincurrency); ;
            Console.WriteLine("Le client a été crée");
        }

        private void unblockClient(Client client)
        {
            client.IsCardBlocked = false;

        }

        private void blockClient(Client client)
        {
            client.IsCardBlocked = true;
        }

        private void changePin(Client client, int new_pin)
        {
            client.ChangePin(new_pin);
        }

        private void resetTries(Client client)
        {
            client.Tries = 0;
        }

        private void deleteClient(Client client)
        {
            //effacer dans json
            ClientJsonAccess js = new ClientJsonAccess();
            js.DeleteClient(client.Id);
            // effacer dans la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.DeleteClient(client.Id);
        }

        private void listeClient()
        {
            // affiche liste des clients dans le json
            ClientJsonAccess js = new ClientJsonAccess();
            js.GetAll();
            // affiche liste des clients dans la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.GetAll();
        }
        private void GetClient(Client c)
        {
            // affiche les informations client du fichier json
            ClientJsonAccess js = new ClientJsonAccess();
            js.GetClient(c.Id);
            // affiche les informations client de la base de données
            ClassDBAccess cb = new ClassDBAccess();
            cb.GetClient(c.Id);
        }

    }
}