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
            // � faire avec la base de donn�es
            Console.WriteLine("Le client a �t� cr�e");
        }

        private void unblockClient(Client client)
        {
            client.isBlocked = false;
            // � faire avec la base de donn�es
        }

        private void blockClient(Client client)
        {
            client.isBlocked = true;
            // � faire avec la base de donn�es
        }

        private void changePin(Client client)
        {
            client._pin = true;
            // � faire avec la base de donn�es
        }

        private void resetTries(Client client)
        {
            client.tries = 0;
            // � faire avec la base de donn�es
        }

        private void deleteClient(Client client)
        {
           // � faire avec la base de donn�es
        }

        private void listeClient()
        {
            // � faire avec la base de donn�es
        }

    }