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
                ShowMainMenu();

                userCommand = int.TryParse(Console.ReadLine(), out userCommand) ? userCommand : 99;

                switch (userCommand)
                {
                    case 0:
                        Console.WriteLine("\nAvslutar programmet...");
                        isRunning = false;
                        break;
                    case 1:
                        Console.WriteLine("\nDu valde att köpa en enkelbiljett. Var god ange ålder:");
                        int age = -1;
                        if (int.TryParse(Console.ReadLine(), out age) && age >= 0)
                        {
                            decimal price = GetTicketPrice(age);
                            Console.WriteLine($"\nDitt biljettpris är: {price:C}.");
                        }
                        else
                            Console.WriteLine("Ogiltig ålder angiven.");

                        break;
                    case 2:
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
                            Console.WriteLine("Ogiltigt gruppantal angivet.");

                        break;
                    case 3:
                        Console.WriteLine("\nDu valde att upprepa tio gånger. Var god ange en text:");
                        string inputText = Console.ReadLine() ?? string.Empty;
                        for (int i = 1; i <= 10; i++)
                        {
                            Console.Write($"{i}. {inputText}");
                            string lineEnding = ", ";
                            if (i < 10)
                                Console.Write(lineEnding);
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nDu valde det tredje ordet. Var god ange en mening med minst 3 ord:");
                        string inputText2 = Console.ReadLine() ?? string.Empty;
                        string[] words = inputText2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length > 2)
                            Console.WriteLine($"\nDet tredje ordet är: {words[2]}");
                        else
                            Console.WriteLine("\nMeningen innehåller färre än 3 ord.");
                        break;
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
    }
}
