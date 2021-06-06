using System;

namespace NumberCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            long longMin = long.MinValue;
            long longMax = long.MaxValue;

            Console.WriteLine($"Welcome to the number counting name!");
            Console.WriteLine($"Please enter a number between 0 and {longMax}:");

            string userInput = Console.ReadLine();
            long userInputNumber = long.Parse(userInput);
            bool wantToQuit = false;

            long currentNumber = 0;
            do
            {
                string userInput = Console.ReadLine();
                long userInputNumber = long.Parse(userInput);

                if (userInputNumber == 24)
                {
                    Console.WriteLine($"Lee loves Terese!");
                }
                
                while (currentNumber < userInputNumber+1)
                {
                    Console.WriteLine($"{currentNumber}");
                    currentNumber++;
                }

                Console.WriteLine($"Do you want to count again? (Y/N):");
                string countAgainInput = Console.ReadLine();

                if (countAgainInput.ToLower() == "n")
                {
                    wantToQuit = true;
                }
            }
            while (wantToQuit == false);
        }
    }
}
