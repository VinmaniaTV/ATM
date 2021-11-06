using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropService;
using System.Runtime.dll;

namespace ATM
{
    class Admin
    {
        private void createClient (Guid _id, int _pin, int _ammount)
        {
            Client client = new Client(_id, _pin, _ammount);
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