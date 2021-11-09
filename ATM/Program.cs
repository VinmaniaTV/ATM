using System;
using System;
using System.Data.SQLite;
namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello.");
            Console.WriteLine("      ");
            Console.WriteLine("Welcome to StockCash, the bank that cares about you");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("Are you an admin? (Yes ou No)");
            string m = Console.ReadLine();
            if (m == "Yes")
            {
                List<string> list = new List<string>();
                Console.WriteLine("Username:");
                list.Add(Console.ReadLine());
                Console.WriteLine("Password:");
                list.Add(Console.ReadLine());
                
                ClientJsonAccess js = new ClientJsonAccess();
                bool cho =js.GetAdmin(list[0], list[1]);
                if (!cho)
                {
                    Console.WriteLine("Username or password are incorrect.");
                }
                else
                {
                    Console.WriteLine("You are connected as an admin.");
                    Admin admin = new Admin(list[0], list[1]);
                    Console.WriteLine("What do you want to do? (create client, delete client, block client, unblock client, getAllClient, GetClient)");
                    string module = Console.ReadLine();
                    bool exit = false;
                    while (!exit)
                    {
                        if (module == "create client")
                        {
                            Console.WriteLine("guid:");
                            Guid guid = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Pin:");
                            int pin = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("FirstName:");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("LastName:");
                            string Lastname = Console.ReadLine();
                            Console.WriteLine("ammount main currency:");
                            float ammount = (float)Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("List of currencies(currency_name_1 currency_name_2):");
                            string currencies = Console.ReadLine();
                            List<string> cur = currencies.Split(" ").ToList();
                            Console.WriteLine("Name of Main currency:");
                            string maincurrency = Console.ReadLine();
                            admin.createClient(guid, pin, firstname, Lastname, ammount, cur, maincurrency);

                        }
                        if (module == "delete client")
                        {
                            Console.WriteLine("Do you know his guid? (Yes ou No)");
                            string know = Console.ReadLine();
                            if (know == "No")
                            {
                                Console.WriteLine("Voici la liste des clients:");
                                admin.GetAllClient();
                            }
                            Console.WriteLine("Guid:");
                            Guid guid = Guid.Parse(Console.ReadLine());
                            admin.DeleteClient(guid);
                        }
                        if (module == "block client")
                        {
                            Console.WriteLine("Do you know his guid? (Yes ou No)");
                            string known = Console.ReadLine();
                            if (known == "No")
                            {
                                Console.WriteLine("Voici la liste des clients:");
                                admin.GetAllClient();
                            }
                            Console.WriteLine("Guid:");
                            Guid guid = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("The card of the client has been block");

                        }
                        if (module == "unblock client")
                        {
                            Console.WriteLine("Do you know his guid? (Yes ou No)");
                            string known = Console.ReadLine();
                            if (known == "No")
                            {
                                Console.WriteLine("Voici la liste des clients:");
                                admin.GetAllClient();
                            }
                            Console.WriteLine("Guid:");
                            Guid guid = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("The card of the client has been unblock");

                        }
                        if (module == "getAllClient")
                        {
                            admin.GetAllClient();
                        }
                        if (module == "getClient")
                        {
                            Console.WriteLine("Do you know his guid? (Yes ou No)");
                            string known = Console.ReadLine();
                            if (known == "No")
                            {
                                Console.WriteLine("Voici la liste des clients:");
                                admin.GetAllClient();
                            }
                            Console.WriteLine("Guid:");
                            Guid guid = Guid.Parse(Console.ReadLine());
                            admin.GetClient(guid);
                        }
                        Console.WriteLine("Do you want to exit? (Yes or No");
                        string exi = Console.ReadLine();
                        if (exi == "Yes")
                        {
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("What do you want to do? (create client, delete client, block client, unblock client, getAllClient, GetClient)");
                            module = Console.ReadLine();
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Do you already have an account here? (Yes ou No)");
                string n = Console.ReadLine();
                if (n == "Yes")
                {
                    Console.WriteLine("what is your Id");
                    Guid id = Guid.Parse(Console.ReadLine());
                    ClientJsonAccess js = new ClientJsonAccess();
                    bool boll = js.GetClientId(id);
                    if (!boll)
                    {
                        Console.WriteLine("your guid is incorect");
                    }
                    else
                    {
                        Console.WriteLine("what is your pin");
                        int pin = Convert.ToInt32(Console.ReadLine());
                        if (js.GetClientPin(id) == pin)
                        {
                            Console.WriteLine("you are connected");
                            Client client = js.client(id);
                            Console.WriteLine("what do you want to do? (View All,Addmoney,retrivemoney,change pin,check ammount,block card,change main currency");
                            string s = Console.ReadLine();
                            if (s == "Addmoney")
                            {
                                Console.WriteLine("ammount");
                                string ammount = Console.ReadLine();
                                float ammount1 = float.Parse(ammount);
                                client.addAmmountMainCurrency(ammount1);

                            }
                            else if (s == "View All")
                            {
                                Console.WriteLine("Guid:" + client.Id);
                                Console.WriteLine("FirstName:" + client.FirstName);
                                Console.WriteLine("LastName:" + client.LastName);
                                Console.WriteLine("AmmountMainCurrency:" + client.AmmountMainCurrency);
                                Console.WriteLine("List Currencies:" + client.CurrencyName);
                                Console.WriteLine("MainCurrency:" + client.Maincurrency);

                            }
                            else if (s == "retrivemoney")
                            {
                                Console.WriteLine("ammount");
                                string ammount = Console.ReadLine();
                                float ammount1 = float.Parse(ammount);
                                client.retrieveAmmount(ammount1);

                            }
                            else if (s == "change pin")
                            {
                                Console.WriteLine("new_pin");
                                int new_pin = Convert.ToInt32(Console.ReadLine());
                                client.ChangePin(new_pin);

                            }
                            else if (s == "check ammount")
                            {
                                client.checkBalance();
                            }
                            else if (s == "block card")
                            {
                                client.blockCard();
                                Console.WriteLine("card blocked");
                            }
                            else if (s == "change main currency")
                            {
                                Console.WriteLine("new_currency");
                                string new_currency = Console.ReadLine();
                                client.exchangeCurrency(new_currency);
                            }
                            else
                            {
                                Console.WriteLine("you did not choose a feature");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your pin is incorrect. Try again.");
                        }


                    }

                }
                else
                {
                    Console.WriteLine("Ask to an admin to cretes you an account.");
                }
            }
        }
    }
}
   

