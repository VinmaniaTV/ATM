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
        private bool isCardBlocked=false;
        private int tries=0;
        private bool isLoggedIn=false;


        public Client(int _id,int _pin, int _ammount)
        {
            id=_id;
            pin= checkPinSizeAndType(_pin)? _pin : 0000 ;
            ammount=_ammount;


        }


        private bool checkPinSizeAndType(int pin)
        {
            //see if pin if between 4 and 6 int
            return true;
        }



        public bool validatePin(int _pin)
        {
            
            if (checkPinSizeAndType(pin))
            {
                //check if the pin is the same
                //if true
                //set isloggedin to true
                return true;

                //if false 
                //increment tries 
                //and check to see if the card is blocked
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
                isCardBlocked=true;
            }
        }

        public void unBlockCard()
        {
            
            isCardBlocked = false;
            tries=0;
            
        }

        public void retrieveAmmount(int _ammount)
        {
            if (isLoggedIn)
            {
                bool b=checkAmmount(_ammount);
                if (b)
                {
                    //retrieve
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
            return true;

            //else
            return false;
            
        }

        public void exitAccount()
        {
            isLoggedIn=false;
        }
    }
}
