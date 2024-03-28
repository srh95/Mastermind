using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mastermind;

namespace Mastermind.Tests{
 [TestClass]
    public class MastermindGameTests{
        [TestMethod]
        public void GenerateRandomNumber_ReturnsCorrectLength(){
            MastermindGame game = new MastermindGame();
            int numDigits = 4;

            string result = game.GenerateRandomNumber(numDigits);

            Assert.AreEqual(numDigits, result.Length, "Generated number length should be 4");
        }

        [TestMethod]
        public void GenerateRandomNumber_ContainsOnlyValidDigits(){

            MastermindGame game = new MastermindGame();
            int numDigits = 4;

            string result = game.GenerateRandomNumber(numDigits);

            foreach (char digit in result)
            {
                int num;
                bool isNumber = int.TryParse(digit.ToString(), out num);
                Assert.IsTrue(isNumber && num >= 1 && num <= 6, "Generated number should only contain digits between 1 and 6");
            }
        }

        [TestMethod]
        public void GenerateRandomNumber_ReturnsDifferentNumbers(){
            MastermindGame game = new MastermindGame();
            int numDigits = 4;

            string result1 = game.GenerateRandomNumber(numDigits);
            string result2 = game.GenerateRandomNumber(numDigits);

            Assert.AreNotEqual(result1, result2, "Generated numbers should be different");
        }

        [TestMethod]
        public void EvaluateGuess_AllCorrect_ReturnsFourPlus(){
            string secretNum = "6543";
            string userGuess = "6543";
            MastermindGame game = new MastermindGame();

            string result = game.EvaluateGuess(secretNum, userGuess);

            Assert.AreEqual("++++", result);
        }

        [TestMethod]
        public void EvaluateGuess_AllIncorrect_ReturnsNothing(){
            string secretNum = "1234";
            string userGuess = "5678";
            MastermindGame game = new MastermindGame();

            string result = game.EvaluateGuess(secretNum, userGuess);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void EvaluateGuess_TwoCorrectDigits_ReturnsTwoMinus(){
            string secretNum = "1356";
            string userGuess = "6124";
            MastermindGame game = new MastermindGame();

            string result = game.EvaluateGuess(secretNum, userGuess);

            Assert.AreEqual("--", result);
        }

        [TestMethod]
        public void EvaluateGuess_TwoCorrectDigitAndPosition_ReturnsTwoPlus(){
            string secretNum = "1356";
            string userGuess = "4256";
            MastermindGame game = new MastermindGame();

            string result = game.EvaluateGuess(secretNum, userGuess);

            Assert.AreEqual("++", result);
        }

        [TestMethod]
        public void EvaluateGuess_AllCorrectDigitTwoCorrectPosition_ReturnsTwoPlusTwoMinus(){
            string secretNum = "1356";
            string userGuess = "1365";
            MastermindGame game = new MastermindGame();

            string result = game.EvaluateGuess(secretNum, userGuess);

            Assert.AreEqual("++--", result);
        }


    }
}