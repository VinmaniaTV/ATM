using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Client
    {
        private int id;
        private int pin;
        private int ammount;
        private bool isCardBlocked = false;
        private int tries = 0;
        private bool isLoggedIn = false;


        public Client(int _id, int _pin, int _ammount)
        {
            id = _id;
            pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            ammount = _ammount;


        }

        public Client()
        {

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

        private bool checkAmmount(int _ammount)
        {
            //if ammount>0 <=ammount
            if (ammount > 0 && _ammount <= ammount) return true;

            //else
            return false;

        }

        public void exitAccount()
        {
            isLoggedIn = false;
        }
    }
}
