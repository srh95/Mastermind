using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args){

            int gamesPlayed = 0;
            int gamesWon = 0;
            bool playAgain = true;

            MastermindGame game = new MastermindGame();

            // Display rules and prompt user to start the game
            Console.WriteLine("Welcome to Mastermind! \n");
            Console.WriteLine("I'm thinking of a 4-digit number, where each digit has a value between 1 and 6. Can you try and guess it? \n");
            Console.WriteLine("Each time you guess, I will give you a hint. For every correct digit in the correct position, you'll get a (+).");
            Console.WriteLine("For every correct digit in the wrong position, you'll get a (-). \n");
            Console.WriteLine("You'll get nothing for wrong digits. \n");
            Console.WriteLine("You win if you guess my number in 10 tries or less!\n\n");
            Console.WriteLine("Press enter to start! Type 'quit' if you want to exit. \n");

            var userInput = Console.ReadLine()!;

            if (userInput.ToLower() == "quit"){
                Console.WriteLine("Goodbye!");
                return;
            }

            // Loop so user can play again
            while(playAgain){

                gamesPlayed++;

                bool gameWon = game.Start();

                if(gameWon)
                    gamesWon++;

                Console.WriteLine("You've played " + gamesPlayed + " games and you've won " + gamesWon + " games.");

                Console.WriteLine("\nPress enter to play again. Type 'quit' if you want to exit.");
                
                var userEntry = Console.ReadLine()!;

                if(userEntry.ToLower() == "quit")
                    playAgain = false;
            }
            Console.WriteLine("Goodbye!");
        }
    }
}