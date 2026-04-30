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
                Console.WriteLine("\n.:Välkommen till huvudmenyn!:.\n");
                Console.WriteLine("Skriv in siffran för det alternativ du vill välja:");
                Console.WriteLine("0. Avsluta programmet");
                Console.WriteLine("1. Köp enkelbiljett");
                Console.WriteLine("2. Köp biljetter för ett sällskap");
                Console.WriteLine("3. Upprepa tio gånger");
                Console.WriteLine("4. Det tredje ordet\n");

                userCommand = int.TryParse(Console.ReadLine(), out userCommand) ? userCommand : 99;

                switch (userCommand)
                {
                    case 0:
                        Console.WriteLine("\nAvslutar programmet...");
                        isRunning = false;
                        break;
                    case 1:
                        Console.WriteLine("\nDu valde att köpa en enkelbiljett.");
                        break;
                    case 2:
                        Console.WriteLine("\nDu valde att köpa biljetter för ett sällskap.");
                        break;
                    case 3:
                        Console.WriteLine("\nDu valde att upprepa tio gånger.");
                        break;
                    case 4:
                        Console.WriteLine("\nDu valde det tredje ordet.");
                        break;
                    default:
                        Console.WriteLine("\nDu har gett ett felaktigt kommando. Var god försök igen.");
                        break;
                }
            }
        }
    }
}
