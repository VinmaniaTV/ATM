using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropService;
using System.Runtime.dll;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace ATM
{
    class Client
    {
        private Guid id;
        private int pin;
        private string firstName;
        private string lastName;
        private int ammountMainAccount;
        private List<string> account;
        private string mainAccount;
        private bool isCardBlocked = false;
        private int tries = 0;
        private bool isLoggedIn = false;

        public Guid Id
        {
            get { return id;}
            set { id = value; }
        }
        public int Pin
        {
            set { pin = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int AmmountMainAccount
        {
            get { return ammountMainAccount; }
            set { ammountMainAccount = value; }
        }
        public string MainAccount
        {
            set { mainAccount = value; }
            get { return mainAccount; }
        }

         public List<string> Account
        {
            get { return account; }
            set { account = value; }
        }

         public bool IsCardBlocked
        {
            get { return isCardBlocked; }
            set { isCardBlocked = value; }
        }
        public int Tries
        {
            get { return tries; }
            set { tries = value; }
        }

         public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { isLoggedIn = value; }
        }

        public Client(Guid _id, int _pin, int _ammount)
        {
            this.Id = _id;
            this.Pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.AmmountMainAccount = _ammount;
        }
        public Client(Guid _id, int _pin, int _ammount, List<string> account, string mainAccount)
        {
            this.Id = _id;
            this.Pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.AmmountMainAccount = _ammount;
            this.Account = account;
            this.MainAccount = mainAccount;
          

        }



        private bool checkPinSizeAndType(int pin)
        {
            //see if pin if between 4 and 6 int
            if (pin.GetType() == typeof(int) && pin.ToString().Length <= 6 && pin.ToString().Length >= 4)
            {
                return true;
            }
            else
            {
                Console.WriteLine("input incorrect.");
                return false;
            }
        }


        public bool checkIsLocked()
        {
            return isCardBlocked;
        }


        public bool validatePin(int _pin)
        {

            if (checkPinSizeAndType(_pin))
            {
                //check if the pin is the same
                if (pin == _pin)
                {
                    //if true
                    //set isloggedin to true
                    isLoggedIn = true;
                    return true;
                }

                //if false 
                else
                {
                    //increment tries
                    tries++;
                    //and check to see if the card is blocked
                    blockCard();
                }

            }

            return false;
        }
        

        public int checkBalance()
        {
            return ammountMainAccount;
        }
        public int checkBalanceByAccount(string accountsearch)
        {
            int n=0;
            for (int i =0, i<this.account.lenght, i++)
            {
                if(this.account[i][0]== accountsearch)
                {
                    n = this.account[i][1];
                }
            }
            return n;
        }

        public List checkAllBalance()
        {
            return account;
        }
        public void blockCard()
        {
            if (tries == 3)
            {
                isCardBlocked = true;
                Console.WriteLine("Your card is blocked.");
            }
            else if (tries < 3)
            {
                Console.WriteLine("Your pin is incorrect. You still have " + 3-tries + " tries.");
            }
        }

        public void unBlockCard()
        {

            isCardBlocked = false;
            tries = 0;

        }

        public void retrieveAmmountMainAccount(int _ammount)
        {
            if (isLoggedIn)
            {
                bool b = checkAmmount(_ammount);
                if (b)
                {
                    //retrieve
                    ammountMainAccount -= _ammount;
                    Console.WriteLine("you withdrawed " + _ammount + "$.");
                    Console.WriteLine("account: " + ammountMainAccount + "$.");
                }
                else
                {
                    Console.WriteLine("you dont have enought money");
                }

            }
            else
            {
                Console.WriteLine("not logged in");
            }
        }
        public void retrieveAmmountByAccount(int _ammount, string _account)
        {
            if (isLoggedIn)
            {
                bool b = checkAmmountByAccount(_ammount,_account);
                if (b)
                {
                    //retrieve
                    for (int i =0, i<this.account.lenght, i++)
                     {
                        if(this.account[i][0]== _account)
                        {
                                this.account[i][1] -= _ammount;
                                Console.WriteLine("you withdrawed " + _ammount + "$.");
                                Console.WriteLine("account: " + this.account[i][1]+ "$.");
                        }
                     }
                }
                else
                {
                    Console.WriteLine("you dont have enought money");
                }

            }
            else
            {
                Console.WriteLine("not logged in");
            }
        }
        public void addAmmountMainAccount(int _ammount)
        {
            if (isLoggedIn)
            {
               
                if (_ammount>0)
                {
                    //add
                    ammountMainAccount += _ammount;
                    Console.WriteLine("you add " + _ammount + "$.");
                    Console.WriteLine("account: " + ammountMainAccount + "$.");
                }
                
            }
            else
            {
                Console.WriteLine("You can't add negative or zero ammount of money in your account.");
            }
        }
                public void addAmmountByAccount(int _ammount,string _account)
        {
            if (isLoggedIn)
            {
               
                if (_ammount>0)
                {
                    //add
                    for (int i =0, i<this.account.lenght, i++)
                     {
                        if(this.account[i][0]== _account)
                        {
                                this.account[i][1] += _ammount;
                                Console.WriteLine("you add " + _ammount + "$.");
                                Console.WriteLine("account: " + this.account[i][1]+ "$.");
                        }
                     }
                }
                
            }
            else
            {
                Console.WriteLine("You can't add negative or zero ammount of money in your account.");
            }
        }

        private bool checkAmmount(int _ammount)
        {
            //if ammount>0 <=ammount
            if (ammountMainAccount > 0 && _ammount <= ammountMainAccount) return true;

            //else
            return false;

        }

        private bool checkAmmountByAccount(int _ammount, string _account)
        {
            int ammountPrefAccount = checkBalanceByAccount(_account);
            
            if (ammountPrefAccount > 0 && _ammount <= ammountPrefAccount) return true;

            //else
            return false;

        }

        public void ChangePin(int new_pin)
        {
            if (isLoggedIn)
            {
                if (checkPinSizeAndType(new_pin)) { 
                    Console.WriteLine("Enter your current pin: ");
                    int checkPin = Convert.ToInt32(Console.ReadLine());
                    if (validatePin(checkPin))
                    { 
                        pin = new_pin;
                        Console.WriteLine("Your pin has been change.");
                    }
                }
                else
                {
                   Console.WriteLine("Your new pin is incorrect.")  
                }
                
            }
            else
            {
                Console.WriteLine("You are not connected.");
            }
            

        }
        public void exchangeMoneyBetweenMyCurrencies()
        {
            bool existe = false;
            Console.WriteLine("De quelle compte voulez vous envoyer de l'argent?");
            string n = Console.ReadLine();
            for (int i =0, i<this.account.lenght, i++)
            {
              if(this.account[i][0]== n)
              {
                existe=true;
              }
            }
            while (!existe)
            {
                Console.WriteLine("Ce compte n'existe pas. Voulez Vous voir vos compte (Oui ou Non)?")
                if(Console.ReadLine() == "Oui") { 
                    Console.WriteLine(checkAllBalance());
                }
                Console.WriteLine("De quelle compte voulez vous envoyer de l'argent?");
                string n = Console.ReadLine();
                for (int i =0, i<this.account.lenght, i++)
                {
                    if(this.account[i][0]== n)
                    {
                        existe=true;
                    }
                }                
            }
            Console.WriteLine("Vers quel compte voulez vous envoyer de l'argent?");
            string m = Console.ReadLine();
            for (int i =0, i<this.account.lenght, i++)
            {
              if(this.account[i][0]== m)
              {
                existe=true;
              }
            }
            while (!existe)
            {
                Console.WriteLine("Ce compte n'existe pas. Voulez Vous voir vos compte (Oui ou Non)?")
                if(Console.ReadLine() == "Oui") { 
                    Console.WriteLine(checkAllBalance());
                }
                Console.WriteLine("De quelle compte voulez vous envoyer de l'argent?");
                string n = Console.ReadLine();
                for (int i =0, i<this.account.lenght, i++)
                {
                    if(this.account[i][0]== m)
                    {
                        existe=true;
                    }
                }                
            }
            Console.WriteLine("Combien d'argent?");
            int s = Convert.ToInt32(Console.ReadLine());
            if (checkAmmountByAccount(s, n))
            {
                retrieveAmmountByAccount(s,n);
                addAmmountByAccount(s,m);
                Console.WriteLine("L'opération a été un succés.")
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez d'argent sur votre compte")
            }

        }

        public void exitAccount()
        {
            isLoggedIn = false;
        }
    }
}
