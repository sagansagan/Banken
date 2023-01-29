using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace Banken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //deklarerar arrays för namn, pin och konton
            string[] username = new string[] { "Sara", "Konrad", "Staffan", "Greta", "Hans" };
            int[] pincode = new int[] { 111, 123, 321, 1212, 112 };
            string[][] accountNames = new string[5][];
            double[][] accountBalances = new double[5][];

            accountNames[0] = new string[] { "Lönekonto", "Sparkonto" };
            accountNames[1] = new string[] { "Lönekonto", "Sparkonto", "Kapitalkonto" };
            accountNames[2] = new string[] { "Lönekonto", "Sparkonto", "ISK", "Fondkonto" };
            accountNames[3] = new string[] { "Lönekonto", "Sparkonto", "Pension", "Bostadssparande", "Fondkonto" };
            accountNames[4] = new string[] { "Lönekonto", "Sparkonto", "ISK", "Företagskonto", "Kapitalkonto", "PENGAR" };

            accountBalances[0] = new double[] { 1200.00, 30000.00 };
            accountBalances[1] = new double[] { 200.00, 5000.00, 450.45 };
            accountBalances[2] = new double[] { 13944.05, 4345.00, 150000.56, 36055.30 };
            accountBalances[3] = new double[] { 3677.23, 4560.00, 50000.93, 400000.32, 60000.21 };
            accountBalances[4] = new double[] { 1500.00, 3400.60, 35000.43, 96483.76, 600.23, 6000000.00 };

           
            Console.WriteLine("Välkommen till min bank!");

            int attemptsLeft = 3;
            bool myBool = true;

            while (myBool)
            {

                Console.Write("Skriv in användarnamn: ");
                string userInput = Console.ReadLine();

                Console.Write("Skriv in pinkod: ");
                int pin;
                int.TryParse(Console.ReadLine(), out pin);
                attemptsLeft--;

                for (int i = 0; i < username.Length; i++)
                {

                    if (userInput.ToUpper() == username[i].ToUpper() && pin == pincode[i])
                    {
                        attemptsLeft = 3;
                        UserMenu(i, username, pincode, accountNames, accountBalances);
                        break;
                        
                    }
                    else 
                    {
                        
                        Console.WriteLine("Inloggningen misslyckades. Du har " + attemptsLeft + " försök kvar.");
                        break;
                    }

                }
                if (attemptsLeft == 0)
                {
                    Console.WriteLine("Programmet stängs nu ner.");
                    myBool = false;
                }

            }

            //LogIn(username, pincode, accountNames, accountBalances);


            /*
                Console.Write("lösenord:");
                bool isValid = Int32.TryParse(Console.ReadLine(), out pin);
              

                if (isValid)
                {

                }//Använder metoden TryParse för felhantering

               
            }*/
            //funktion för att logga in på banken
            //static void LogIn(string[] userName, int[] pinCode, string[][] accounts, double[][] balances)
            //{
                
            //    int allowedAttempts = 3;
            //    bool myBool = true;
              
             

            //    while(myBool)
            //    {

            //            Console.Write("Ditt användarnamn: ");
            //            string userInput = Console.ReadLine();

            //            Console.Write("Skriv in pinkod: ");
            //            int pin;
            //            int.TryParse(Console.ReadLine(), out pin);

            //        for (int i = 0; i < userName.Length; i++)
            //        {

            //            if (userInput.ToUpper() == userName[i].ToUpper() && pin == pinCode[i])
            //            {

            //                UserMenu(i, userName, pinCode, accounts, balances);
            //                allowedAttempts = 3;
            //            }
            //            else if (i == userName.Length - 1)
            //            {
            //                allowedAttempts--;
            //                Console.WriteLine("Inloggningen misslyckades. Du har " + allowedAttempts + " försök kvar.");
            //                break;
            //            }

            //        }
            //        if (allowedAttempts == 0)
            //        {
            //            Console.WriteLine("Programmet stängs nu ner.");
            //            myBool = false;
            //            Environment.Exit(0);
            //            Console.ReadLine();
            //        }
                    
            //    }
            //}
            //menyfunktion
            static void UserMenu(int userIndex, string[] userName, int[] pinCode, string[][] accounts, double[][] balances)
            {
                bool myMenu = true;

                while (myMenu)
                {
                    Console.Clear();
                    Console.WriteLine($"Välkommen tillbaka {userName[userIndex]}!");
                    Console.WriteLine("Vad vill du göra idag? Välj mellan valen 1-5:\n");
                    Console.WriteLine("1. Se dina konton och saldo");
                    Console.WriteLine("2. Överföring mellan konton");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");

                    Int32.TryParse(Console.ReadLine(), out int choise);

                    switch (choise) 
                    {
                        case 1:
                            for (int i = 0; i < accounts[userIndex].Length; i++)
                            {
                                
                                Console.WriteLine("===================================");
                                Console.WriteLine($"{accounts[userIndex][i]}: {balances[userIndex][i]} kr");
                                Console.WriteLine("===================================");

                            }
                            break;
                        case 2:
                            Transfer(accounts[userIndex], balances[userIndex]);
                            break;
                        case 3:
                            break;
                        case 4:
                            myMenu= false;
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("\nDu måste välja något av siffrorna 1-5 i menyn.");
                            break;
                    }
                    PressEnter();
                    
                }
            }
            //static void ShowAccounts()
            //{
            //    for (int i = 0; i < accounts[userIndex].Length; i++)
            //    {

            //        Console.WriteLine("===================================");
            //        Console.WriteLine($"{accounts[userIndex][i]}: {balances[userIndex][i]} kr");
            //        Console.WriteLine("===================================");

            //    }
            //}
            static void Transfer(string[]accounts, double[]balances)
            {
                Console.WriteLine("Vilket konto vill du föra över från? Välj mellan nummer 1 och " + accounts.Length + " :");
            }

            static void PressEnter()
            {
                Console.WriteLine("\nTryck enter för att gå tillbaka till huvudmenyn.");
                Console.ReadLine();
            }


        }    
    }
}