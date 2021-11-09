using System;
using System.Collections.Generic;
using System.Text;
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
        private float ammountMainCurrency;
        private List<string> currency_name;
        private List<float> currency_ammount;
        private string maincurrency;
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
        public float AmmountMainCurrency
        {
            get { return ammountMainCurrency; }
            set { ammountMainCurrency = value; }
        }
        public string Maincurrency
        {
            set { maincurrency = value; }
            get { return maincurrency; }
        }

         public List<string> CurrencyName
        {
            get { return currency_name; }
            set { currency_name = value; }
        }
        public List<float> Currency_ammount
        {
            get { return currency_ammount; }
            set { currency_ammount = value; }
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
        public Client() { }
        public Client(Guid _id, int _pin, float _ammount)
        {
            this.Id = _id;
            this.Pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.AmmountMainCurrency = _ammount;
        }
        public Client(Guid _id, int _pin, float _ammount, List<string> currency,List<float> currency_ammount, string maincurrency)
        {
            this.Id = _id;
            this.Pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.AmmountMainCurrency = _ammount;
            this.CurrencyName = currency;
            this.Currency_ammount= currency_ammount;
            this.Maincurrency = maincurrency;         
        }
        public Client(Guid _id, int _pin,string _FirstName, string _LastName, float _ammount, List<string> currency, List<float> currency_ammount, string maincurrency)
        {
            this.Id = _id;
            this.Pin = checkPinSizeAndType(_pin) ? _pin : 0000;
            this.FirstName = _FirstName;
            this.LastName = _LastName;
            this.AmmountMainCurrency = _ammount;
            this.CurrencyName = currency;
            this.Currency_ammount = currency_ammount;
            this.Maincurrency = maincurrency;
        }



        private bool checkPinSizeAndType(int pin)
        {
            //see if pin if between 4 and 6 int
            if (pin.GetType() == typeof(int) && pin.ToString().Length == 4)
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
            return IsCardBlocked;
        }


        public bool validatePin(int _pin)
        {

            if (checkPinSizeAndType(_pin))
            {
                //Json pi
                ClientJsonAccess js = new ClientJsonAccess();
                int test = js.GetClientPin(Id);
                if (test == 0)
                {
                    Console.WriteLine("Error with Json MyPin");
                    return false;
                }
                if (test == _pin)
                {
                    //if true
                    //set isloggedin to true
                    IsLoggedIn = true;
                    return true;
                }

                //if false 
                else
                {
                    //increment tries
                    Tries++;
                    //and check to see if the card is blocked
                    blockCard();
                }

            }

            return false;
        }
        

        public float checkBalance()
        {
            return AmmountMainCurrency;
        }
        public float checkBalanceBycurrency(string currencysearch)
        {
            float n=0;
            for (int i =0; i<CurrencyName.Count; i++)
            {
                if(CurrencyName[i]== currencysearch)
                {
                    n = Currency_ammount[i];
                }
            }
            return n;
        }

        public void blockCard()
        {
            if (Tries == 3)
            {
                IsCardBlocked = true;
                Console.WriteLine("Your card is blocked.");
            }
            else if (Tries < 3)
            {
                int n = 3 - Tries;
                Console.WriteLine("Your pin is incorrect. You still have " + n + " tries.");
            }
        }

        public void unBlockCard()
        {

            IsCardBlocked = false;
            Tries = 0;

        }

        public void retrieveAmmount(float _ammount)
        {
            if (IsLoggedIn)
            {
                bool b = checkAmmount(_ammount);
                if (b)
                {
                    //retrieve
                    AmmountMainCurrency -= _ammount;
                    //json
                    ClientJsonAccess js = new ClientJsonAccess();
                    js.UpdateClientFloat(Id," ",AmmountMainCurrency);
                    //base de données
                    ClassDBAccess cb = new ClassDBAccess();
                    cb.UpdateClientFloat(Id,"myAmmountCurrency",AmmountMainCurrency);
                    Console.WriteLine("you withdrawed " + _ammount + "$.");
                    Console.WriteLine("currency: " + AmmountMainCurrency + "$.");
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
        public void retrieveAmmountByCurrency(float _ammount, string _currency)
        {
            if (IsLoggedIn)
            {
                bool b = checkAmmountBycurrency(_ammount,_currency);
                if (b)
                {
                    //retrieve
                    for (int i =0; i<CurrencyName.Count; i++)
                     {
                        if(_currency == CurrencyName[i])
                        {
                                Currency_ammount[i] -= _ammount;
                                //json
                                ClientJsonAccess js = new ClientJsonAccess();
                                js.UpdateCurrencyFloat(Id, " "," ", Currency_ammount[i]);
                                //base de données
                                ClassDBAccess cb = new ClassDBAccess();
                                cb.UpdateCurrencyFloat(Id, "ammount", CurrencyName[i], Currency_ammount[i]);
                                Console.WriteLine("you withdrawed " + _ammount + "$.");
                                Console.WriteLine("currency: " + Currency_ammount[i]+ " "+ CurrencyName[i] );
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
        public void addAmmountMainCurrency(float _ammount)
        {
            if (IsLoggedIn)
            {
               
                if (_ammount>0)
                {
                    //add
                    AmmountMainCurrency += _ammount;
                    //json
                    ClientJsonAccess js = new ClientJsonAccess();
                    js.UpdateClientFloat(Id, " ", AmmountMainCurrency);
                    //base de données
                    ClassDBAccess cb = new ClassDBAccess();
                    cb.UpdateClientFloat(Id, "myAmmountCurrency", AmmountMainCurrency);
                    Console.WriteLine("you add " + _ammount + "$.");
                    Console.WriteLine("currency: " + AmmountMainCurrency + "$.");
                }
                
            }
            else
            {
                Console.WriteLine("You can't add negative or zero ammount of money in your currency.");
            }
        }
        public void addAmmountByCurrency(float _ammount,string _currency)
        {
            if (IsLoggedIn)
            {
               
                if (_ammount>0)
                {
                    //add
                    for (int i =0; i<CurrencyName.Count; i++)
                     {
                        if(CurrencyName[i]== _currency)
                        {
                                Currency_ammount[i] += _ammount;
                                //json
                                ClientJsonAccess js = new ClientJsonAccess();
                                js.UpdateCurrencyFloat(Id, " ", " ", Currency_ammount[i]);
                                //base de données
                                ClassDBAccess cb = new ClassDBAccess();
                                cb.UpdateCurrencyFloat(Id, "ammount", CurrencyName[i], Currency_ammount[i]);
                                Console.WriteLine("you add " + _ammount + "$.");
                                Console.WriteLine("currency: " + Currency_ammount[i]+ " " + CurrencyName[i]);
                        }
                     }
                }
                
            }
            else
            {
                Console.WriteLine("You can't add negative or zero ammount of money in your currency.");
            }
        }

        private bool checkAmmount(float _ammount)
        {
            //if ammount>0 <=ammount
            if (AmmountMainCurrency > 0 && _ammount <= AmmountMainCurrency) return true;

            //else
            return false;

        }

        private bool checkAmmountBycurrency(float _ammount, string _currency)
        {
            float ammountPrefcurrency = checkBalanceBycurrency(_currency);
            
            if (ammountPrefcurrency > 0 && _ammount <= ammountPrefcurrency) return true;

            //else
            return false;

        }

        public void ChangePin(int new_pin)
        {
            if (IsLoggedIn)
            {
                if (checkPinSizeAndType(new_pin)) { 
                    Console.WriteLine("Enter your current pin: ");
                    int checkPin = Convert.ToInt32(Console.ReadLine());
                    if (validatePin(checkPin))
                    { 
                        Pin = new_pin;
                        //json
                        ClientJsonAccess js = new ClientJsonAccess();
                        js.UpdateClientInt(Id," ", new_pin);
                        //base de données
                        ClassDBAccess cb = new ClassDBAccess();
                        cb.UpdateClientInt(Id,"pin",new_pin);
                        Console.WriteLine("Your pin has been change.");
                    }
                }
                else
                {
                    Console.WriteLine("Your new pin is incorrect.");  
                }
                
            }
            else
            {
                Console.WriteLine("You are not connected.");
            }
            

        }
        public void exchangeCurrency(string u)
        {
           
            for (int i = 0; i < CurrencyName.Count; i++)
            {
                if(CurrencyName[i] == u)
                {
                    string t = Maincurrency;
                    float s = AmmountMainCurrency;
                    Maincurrency = CurrencyName[i];
                    AmmountMainCurrency = Currency_ammount[i];
                    Currency_ammount[i] = s;
                    CurrencyName[i] = t;
                    //json
                    ClientJsonAccess js =new ClientJsonAccess();
                    js.UpdateClientFloat(Id, "myAmmountCurrency", AmmountMainCurrency);
                    js.UpdateCurrencyFloat(Id, "ammount", " ", Currency_ammount[i]);
                    js.UpdateClientString(Id, " ", Maincurrency);
                    js.UpdateCurrencyString(Id, " ", " ", Maincurrency);
                    //base de données
                    ClassDBAccess cb = new ClassDBAccess();
                    cb.UpdateClientFloat(Id, "myAmmountCurrency", AmmountMainCurrency);
                    cb.UpdateCurrencyFloat(Id, "ammount", Maincurrency, Currency_ammount[i]);
                    cb.UpdateClientString(Id, "myMainCurrency", Maincurrency);
                    cb.UpdateCurrencyString(Id, "name", CurrencyName[i],Maincurrency);


                }
            }

        }

        public void exit()
        {
            IsLoggedIn = false;
        }
    }
}
