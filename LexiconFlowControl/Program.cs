namespace LexiconFlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            int userCommand = 99;

            while (isRunning)
            {
                // Show main menu with available options
                ShowMainMenu();

                // User selection
                userCommand = int.TryParse(Console.ReadLine(), out userCommand) ? userCommand : 99;

                // Handle user command
                switch (userCommand)
                {
                    // Exit program
                    case 0:
                        Console.WriteLine("\nAvslutar programmet...");
                        isRunning = false;
                        break;

                    // Purchase single ticket
                    case 1:
                        PurchaseSingleTicket();
                        break;

                    // Purchase tickets for a group
                    case 2:
                        PurchaseMultipleTickets();
                        break;

                    // Repeat text ten times
                    case 3:
                        Console.WriteLine("\nDu valde att upprepa tio gånger. Var god ange en text:");
                        string inputText = Console.ReadLine() ?? string.Empty;
                        Console.Write("\n");

                        for (int i = 1; i <= 10; i++)
                        {
                            Console.Write($"{i}. {inputText}");
                            string lineEnding = ", ";
                            if (i < 10)
                                Console.Write(lineEnding);
                        }
                        break;

                    // Retrieve the third word from a sentence
                    case 4:
                        RetrieveThirdWord();
                        break;

                    // Invalid command
                    default:
                        Console.WriteLine("\nDu har gett ett felaktigt kommando. Var god försök igen.");
                        break;
                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("\n\n-------------------------------\n");
            Console.WriteLine("\n.:Välkommen till huvudmenyn!:.\n");
            Console.WriteLine("Skriv in siffran för det alternativ du vill välja:");
            Console.WriteLine("0. Avsluta programmet");
            Console.WriteLine("1. Köp enkelbiljett");
            Console.WriteLine("2. Köp biljetter för ett sällskap");
            Console.WriteLine("3. Upprepa tio gånger");
            Console.WriteLine("4. Det tredje ordet\n");
        }

        // Method to determine ticket price based on age using switch expression
        // Used by both single ticket and group ticket options
        private static decimal GetTicketPrice(int age)
        {
            return age switch
            {
                (< 5 or > 100) => 0m,
                (>= 5 and < 20) => 80m,
                (>= 65 and <= 100) => 90m,
                _ => 120m,
            };
        }

        private static void PurchaseSingleTicket()
        {
            Console.WriteLine("\nDu valde att köpa en enkelbiljett. Var god ange ålder:");
            int age = -1;
            if (int.TryParse(Console.ReadLine(), out age) && age >= 0)
            {
                decimal price = GetTicketPrice(age);
                Console.WriteLine($"\nDitt biljettpris är: {price:C}.");
            }
            else
            {
                Console.WriteLine("Ogiltig ålder angiven. Var god försök igen.");
                // Recursive call to allow user to try again
                PurchaseSingleTicket();
            }
        }

        private static void PurchaseMultipleTickets()
        {
            Console.WriteLine("\nDu valde att köpa biljetter för ett sällskap. Ange antal personer:");
            int groupSize = 0;
            if (int.TryParse(Console.ReadLine(), out groupSize) && groupSize > 0)
            {
                int[] ages = new int[groupSize];
                for (int i = 1; i <= groupSize; i++)
                {
                    Console.WriteLine($"Ange ålder för person {i}:");
                    ages[i - 1] = int.TryParse(Console.ReadLine(), out int personAge) && personAge >= 0 ? personAge : -1;
                }

                decimal totalPrice = 0m;
                foreach (int personAge in ages)
                {
                    if (personAge >= 0)
                        totalPrice += GetTicketPrice(personAge);
                    else
                        Console.WriteLine("Ogiltig ålder angiven för en person i gruppen. Den personen kommer inte att inkluderas i prisberäkningen.");
                }

                Console.WriteLine($"\nTotalt pris för {groupSize} personer: {totalPrice:C}.");
            }
            else
            {
                Console.WriteLine("Ogiltigt gruppantal angivet. Var god försök igen.");
                // Recursive call to allow user to try again
                PurchaseMultipleTickets();
            }
        }

        private static void RetrieveThirdWord()
        {
            Console.WriteLine("\nDu valde det tredje ordet. Var god ange en mening med minst 3 ord:");
            string inputText2 = Console.ReadLine() ?? string.Empty;
            string[] words = inputText2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 2)
                Console.WriteLine($"\nDet tredje ordet är: {words[2]}");
            else
            {
                Console.WriteLine("Meningen innehåller färre än 3 ord.");
                // Recursive call to allow user to try again
                RetrieveThirdWord();
            }
        }
    }
}
