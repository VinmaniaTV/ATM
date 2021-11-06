using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("      ");
            Console.WriteLine("Welcome to StockCash, the bank that cares about you");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("Insert your GUID:");
            Console.ReadLine();
            // TO DO: check with the database if 
            var c = new Client(10, 9999, 100000);

            int am = c.checkBalance();
            Console.WriteLine(am);

            Console.WriteLine("Entrez votre code PIN:");
            int PINTyped = Convert.ToInt32(Console.ReadLine());
            c.validatePin(PINTyped);
            while (!c.checkIsLocked())
            {
                if (c.validatePin(PINTyped))
                {
                    Console.inr
                    Console.WriteLine("Entrez la somme que vous souhaitez retirer:");
                    int ammountToRetrieve;
                    Int32.TryParse(Console.ReadLine(), out ammountToRetrieve);
                    c.retrieveAmmount(ammountToRetrieve);
                    return;
                }
                else
                {
                    Console.WriteLine("Entrez votre code PIN:");
                    PINTyped = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("the card is blocked.");
            return;
        }
    }
}
