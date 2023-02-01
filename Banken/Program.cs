using System.Globalization;

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
            bool runProgram = true;

            while (runProgram)
            {

                Console.Write("Skriv in användarnamn: ");
                string userInput = Console.ReadLine();

                Console.Write("Skriv in pinkod: ");
                int.TryParse(Console.ReadLine(), out int pin);
                attemptsLeft--;

                for (int i = 0; i < username.Length; i++)
                {
                    

                    if (userInput.ToUpper() == username[i].ToUpper() && pin == pincode[i])
                    {
                        attemptsLeft = 3;
                        UserMenu(i, username, pincode, accountNames, accountBalances);
                        
                    }
                    //if (attemptsLeft == 0)
                    //{
                    //    Console.WriteLine("Programmet stängs nu ner.");
                    //    runProgram = false;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Inloggningen misslyckades. Du har " + attemptsLeft + " försök kvar.");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Inloggningen misslyckades. Du har " + attemptsLeft + " försök kvar.");

                    //}
                    //i = int.MaxValue - 1;
                }
                if (attemptsLeft == 0)
                {
                    Console.WriteLine("Programmet stängs nu ner.");
                    runProgram = false;
                }
                else
                {
                    Console.WriteLine("Inloggningen misslyckades. Du har " + attemptsLeft + " försök kvar.");

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

                    int.TryParse(Console.ReadLine(), out int choise);

                    switch (choise)
                    {
                        case 1:
                            Console.Clear();
                            ShowAccounts(accounts[userIndex], balances[userIndex]);
                            break;
                        case 2:
                            Console.Clear();
                            Transfer(accounts[userIndex], balances[userIndex]);
                            break;
                        case 3:
                            Console.Clear();
                            Withdraw(pinCode[userIndex], accounts[userIndex], balances[userIndex]);
                            break;
                        case 4:
                            //myMenu= false;
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("\nDu måste välja något av siffrorna 1-5 i menyn.");
                            break;
                    }
                    PressEnter();

                }
            }

            static void Transfer(string[] accounts, double[] balances)
            {
                Console.Clear();
                Console.WriteLine("============Överföring===========");
                Console.WriteLine("Välj ett konto mellan nummer 1 och " + accounts.Length + " :");
                ShowAccounts(accounts, balances);

                //subtraherar anv svar med 1 för att få rätt index till variablelnamnen
                Console.WriteLine("\nJag vill föra över från konto:");
                int transferFrom = int.Parse(Console.ReadLine());
                Console.WriteLine("Jag vill föra över till konto:");
                int transferTo = int.Parse(Console.ReadLine());
                transferFrom -= 1;
                transferTo -= 1;


                Console.WriteLine("Ange summa:");
                //testar om input är korrekt

                bool validInput = Double.TryParse(Console.ReadLine(), out Double amount);

                if (validInput)
                {

                    if (amount > balances[transferFrom])
                    {
                        Console.WriteLine("Du har inte tillräckligt på det konto du vill föra över från.");

                    }
                    else if (amount <= 0)
                    {
                        Console.WriteLine("Du har valt ett alldeles för lågt belopp.");
                    }
                    else
                    {
                        Console.WriteLine($"\n{amount}kr har nu förts över från: {accounts[transferFrom]} till: {accounts[transferTo]}");
                        balances[transferFrom] -= amount;
                        balances[transferTo] += amount;
                        ShowAccounts(accounts, balances);

                    }

                }
                else
                {
                    Console.WriteLine("not a valid input..");
                }

            }
            static void Withdraw(int pin, string[]accounts, double[]balances)
            {
                Console.WriteLine("==========Ta ut========== \nVälj vilket konto du vill ta ut pengar från genom att skriva in siffran till vänter om kontot\n");
                ShowAccounts(accounts, balances);
                int withdrawFrom = int.Parse(Console.ReadLine());

                Console.Write("Ange summa att ta ut: ");
                bool valid = Double.TryParse(Console.ReadLine(), out Double amount);

                if (valid)
                {
                    Console.Write($"\nDu har valt att ta ut {amount}kr från ditt {accounts[withdrawFrom - 1]}\n\nVänligen bekräfta detta med din pinkod: ");
                    int pincodeInput = int.Parse(Console.ReadLine());
                    if (pincodeInput == pin)
                    {
                        balances[withdrawFrom - 1] -= amount;
                        Console.Clear();
                        Console.WriteLine($"\nPinkod korrekt! {amount}kr har nu tagits ut från ditt {accounts[withdrawFrom - 1]}\n");
                        ShowAccounts(accounts, balances);
                    }
                    else
                    {
                        Console.WriteLine("\nFel pinkod.");
                    }
                   
                }
                else
                {
                    Console.WriteLine("not a valid input");
                }
                
            }
            static void ShowAccounts(string[]accounts, double[]balances)
            {
                Console.WriteLine("Dina konton och saldon:");
                for (int i = 0; i < accounts.Length; i++)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine($"{i + 1}. {accounts[i]} {balances[i]}kr");

                }
            }


            static void PressEnter()
            {
                Console.WriteLine("\nTryck enter för att gå tillbaka till huvudmenyn.");
                Console.ReadLine();
            }


        }
    }
}