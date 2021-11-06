using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropService;
using System.Runtime.dll;

namespace ATM
{
    class Client
    {
        private Guid id;
        private int pin;
        private string firstName;
        private string lastName;
        private int ammount;
        private bool isCardBlocked = false;
        private int tries = 0;
        private bool isLoggedIn = false;

        public Guid id
        {
            get { return id; }
        }
        public int pin
        {
            if (){}
        }
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        public string DatePremiereCommande
        {
            get { return _datePremiereCommande; }
            set { _datePremiereCommande = value; }
        }
        public Commande CommandeActuelle
        {
            get { return _commandeActuelle; }
            set { _commandeActuelle = value; }
        }

        public Client(Guid _id, int _pin, int _ammount)
        {
            this.id = _id;
            this.pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.ammount = _ammount;
           

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
            return ammount;
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

        public void retrieveAmmount(int _ammount)
        {
            if (isLoggedIn)
            {
                bool b = checkAmmount(_ammount);
                if (b)
                {
                    //retrieve
                    ammount -= _ammount;
                    Console.WriteLine("you withdrawed " + _ammount + "$.");
                    Console.WriteLine("account: " + ammount + "$.");
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

        public void addAmmount(int _ammount)
        {
            if (isLoggedIn)
            {
               
                if (_ammount>0)
                {
                    //add
                    ammount += _ammount;
                    Console.WriteLine("you add " + _ammount + "$.");
                    Console.WriteLine("account: " + ammount + "$.");
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
            if (ammount > 0 && _ammount <= ammount) return true;

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

        public void exitAccount()
        {
            isLoggedIn = false;
        }
    }
}
