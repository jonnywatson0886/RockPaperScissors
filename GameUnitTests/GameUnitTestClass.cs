using NUnit.Framework;
using RockPaperSissors.GameEngine;
using RockPaperSissors.Player;
using System;
using System.Threading.Tasks;

namespace GameUnitTests
{
    public class GameUnitTestClass
    {
        [Test]
        [TestCase(GameChoices.Rock, false)]
        [TestCase(GameChoices.Paper, true)]
        [TestCase(GameChoices.Scissors, false)]
        [TestCase(GameChoices.None, false)]
        public async Task InputsTestVsRock(GameChoices choice, bool shouldWin)
        {
            var testPlayer = new HumanPlayer("TestPlayer1")
            {
                SelectedChoice = choice
            };
            var testPlayer2 = new HumanPlayer("TestPlayer2")
            {
                SelectedChoice = GameChoices.Rock
            };
            var gameEngine = new MainGameEngine(testPlayer, testPlayer2);            
            try
            {
                var winner = gameEngine.FindRoundWinner();
                if (shouldWin)
                {
                    Assert.That(winner == testPlayer);
                }
                else
                {
                    Assert.That(winner != testPlayer);
                }
            }
            catch
            {
                Assert.False(shouldWin);
            }
        }

        [Test]
        [TestCase(GameChoices.Rock, true)]
        [TestCase(GameChoices.Paper, false)]
        [TestCase(GameChoices.Scissors, false)]
        [TestCase(GameChoices.None, false)]
        public async Task InputsTestVsScissors(GameChoices choice, bool shouldWin)
        {
            var testPlayer = new HumanPlayer("TestPlayer1")
            {
                SelectedChoice = choice
            };
            var testPlayer2 = new HumanPlayer("TestPlayer2")
            {
                SelectedChoice = GameChoices.Scissors
            };
            var gameEngine = new MainGameEngine(testPlayer, testPlayer2);
            try
            {
                var winner = gameEngine.FindRoundWinner();
                if (shouldWin)
                {
                    Assert.That(winner == testPlayer);
                }
                else
                {
                    Assert.That(winner != testPlayer);
                }
            }
            catch
            {
                Assert.False(shouldWin);
            }
        }

        [Test]
        [TestCase(GameChoices.Rock, false)]
        [TestCase(GameChoices.Paper, false)]
        [TestCase(GameChoices.Scissors, true)]
        [TestCase(GameChoices.None, false)]
        public async Task InputsTestVsPaper(GameChoices choice, bool shouldWin)
        {
            var testPlayer = new HumanPlayer("TestPlayer1")
            {
                SelectedChoice = choice
            };
            var testPlayer2 = new HumanPlayer("TestPlayer2")
            {
                SelectedChoice = GameChoices.Paper
            };
            var gameEngine = new MainGameEngine(testPlayer, testPlayer2);
            try
            {
                var winner = gameEngine.FindRoundWinner();
                if (shouldWin)
                {
                    Assert.That(winner == testPlayer);
                }
                else
                {
                    Assert.That(winner != testPlayer);
                }
            }
            catch
            {
                Assert.False(shouldWin);
            }
        }

        [Test]
        [TestCase(GameChoices.Paper)]
        [TestCase(GameChoices.Rock)]
        [TestCase(GameChoices.Scissors)]
        public async Task CheckForDraw(GameChoices selection)
        {
            var testPlayer = new HumanPlayer("TestPlayer1")
            {
                SelectedChoice = selection
            };
            var testPlayer2 = new HumanPlayer("TestPlayer2")
            {
                SelectedChoice = selection
            };
            var gameEngine = new MainGameEngine(testPlayer, testPlayer2);

            var winner = gameEngine.FindRoundWinner();
            Assert.That(winner != testPlayer && winner != testPlayer2);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public async Task ScoreWinnerTest(int score)
        {
            var testPlayer = new HumanPlayer("test")
            {
                Score = score
            };
            var game = new MainGameEngine(testPlayer, testPlayer);

            var result = testPlayer.CheckForWin(game.winningScore);

            if (score >= game.winningScore)
            {
                Assert.True(result);
            }
            else 
            {
                Assert.False(result);
            }

        }
    }
}
