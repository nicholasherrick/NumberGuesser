using System;

// Namespace
namespace NumberGuesser
{
    // Main Class
    class Program
    {
        // Entry Point Method
        static void Main(string[] args)
        {
            GetAppInfo();

            GreetUser();

            while (true)
            {
                bool askRange = true;
                int maxRange = 0;

                while (askRange)
                {
                    Console.WriteLine("Pick the max range (greater than 1) you'd like to guess to (max 100)");
                    string rangeInput = Console.ReadLine();

                    if (!int.TryParse(rangeInput, out maxRange))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an actual number");
                        continue;
                    }
                    else if (Int32.Parse(rangeInput) > 100 || Int32.Parse(rangeInput) < 2)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Number must be between 1 and 100");
                        continue;
                    }
                    else
                    {
                        maxRange = Int32.Parse(rangeInput);
                        break;
                    }
                }
                // Set random Correct Number
                Random random = new Random();
                int correctNumber = random.Next(1, maxRange);

                // Guess
                int guess = 0;

                Console.WriteLine("Guess a number betwen 1 and {0}", maxRange);

                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    // Make sure input is a number
                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an actual number");
                        continue;
                    }

                    // Parse the integer
                    guess = Int32.Parse(input);

                    if (guess != correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Wrong number, please try again");
                    }
                }

                // Success
                PrintColorMessage(ConsoleColor.Yellow, "You are Correct!");

                string answer = "";

                while (answer != "Y" || answer != "N") {
                    Console.WriteLine("Play again? [Y or N]");
                    answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        break;
                    }
                    else if (answer == "N")
                    {
                        return;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter either 'Y' or 'N'");
                        continue;
                    }
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Nicholas Herrick";

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to {0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();

        }

        static void GreetUser()
        {
            Console.WriteLine("What is your name?");

            string nameInput = Console.ReadLine();

            Console.WriteLine("Hello {0}, let's play a game.", nameInput);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
