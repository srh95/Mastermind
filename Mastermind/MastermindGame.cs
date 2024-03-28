using System;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;

namespace Mastermind {


    /// <summary>
    /// Represents the Mastermind game.
    /// </summary>
    public class MastermindGame{

        /// <summary>
        /// Starts the Mastermind game.
        /// </summary>
        /// <returns>True if the user wins the game, otherwise false.</returns>
        public bool Start() {

            int guessesLeft = 10;
            string secretNum = GenerateRandomNumber(4);

            // Loops for 10 guesses
            while(guessesLeft > 0){

                Console.WriteLine("\nYou have " + guessesLeft + " guesses remaining. \n");
                Console.WriteLine("Enter your guess: \n");

                string userInput = Console.ReadLine()!;

                // Check if the user wants to quit
                if (userInput.ToLower() == "quit") {
                    return false;
                }
            
                string? userGuess = CheckValidInput(userInput);

                if(userGuess == null){
                    guessesLeft--;
                    continue;
                }

                string hint = EvaluateGuess(secretNum, userGuess);
                Console.WriteLine(hint);

                if(hint == "++++"){
                    Console.WriteLine("\nYou correctly guessed the number in " + (10 - guessesLeft + 1) + " guesses! You win!");
                    return true;
                }
                guessesLeft--;
            }

            Console.WriteLine("\nYou lose! My number was " + secretNum + ". Better luck next time!");
            return false;
        }

        // <summary>
        /// Generates a random 4-digit number.
        /// </summary>
        /// <param name="numDigits"> The number of digits in the random number. </param>
        /// <returns> A string representing the random number. </returns>
        public string GenerateRandomNumber(int numDigits){
            Random random = new Random();
            StringBuilder secretNumBuilder = new StringBuilder();
            int randomNum = 0;
            for(int i=0; i < numDigits; i++){
                randomNum = random.Next(1,7);
                secretNumBuilder.Append(randomNum);
            }
            return secretNumBuilder.ToString();
        }

        /// <summary>
        /// Evaluates the user's guess and returns a hint.
        /// </summary>
        /// <param name="secretNum"> The secret number to guess. </param>
        /// <param name="userGuess"> The user's guess. </param>
        /// <returns> A string representing the hint. </returns>
         public string EvaluateGuess(string secretNum, string userGuess){
            int correctNumber = 0;
            int correctPosition = 0;
            for(int i = 0; i < userGuess.Length; i++){
                if(secretNum[i] == userGuess[i]){
                    // Checks if the digit is in the same position as the secret number
                    correctPosition++;
                } else if(secretNum.Contains(userGuess[i].ToString())){
                    // Checks if the digit is contained in the secret number at all
                    correctNumber++;
                }
            }
            return new string('+', correctPosition) + new string('-', correctNumber);
        }

        /// <summary>
        /// Checks if the user's input is a valid 4-digit number.
        /// </summary>
        /// <param name="userInput"> The user's input. </param>
        /// <returns> The valid user guess or null if the input is invalid. </returns>
        public string? CheckValidInput(string userInput){
            int userGuess;
            // Checks that the input is a number
            bool isNumber = int.TryParse(userInput, out userGuess);

            if(isNumber && userInput.Length == 4){
                return userInput; 
            }else {
                Console.WriteLine("\nInvalid input. Enter a four digit number.");
                return null;
            }
        }
    }
}