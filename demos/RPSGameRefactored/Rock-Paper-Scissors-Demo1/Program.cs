using System;

namespace Rock_Paper_Scissors_Demo1
{
	class Program
	{
		static void Main(string[] args)
		{
			bool playAgain = true;
			do
			{
				//int convertedNumber = -1;
				//bool conversionBool = false;
				Choice computerChoice;
				Choice userChoice = Choice.invalid;
				Console.WriteLine("Hello. Welcome to Rock-Paper-Scissors Game!");
				Console.WriteLine("What is your First Name?");
				string userFName = Console.ReadLine();
				Console.WriteLine("What is your Last Name?");
				string userLName = Console.ReadLine();

				GamePlayLogic game = new GamePlayLogic();
				// log in the player
				game.Login(userFName, userLName);


				//loop here till one player has won 2
				//call the WinnerYet method to see i there's a winner
				while (game.WinnerYet() == null)
				{
					//get user choice and validate
					do
					{
						Console.WriteLine("Please enter enter 1 for ROCK, 2 for PAPER, 3 for SCISSORS.\n");
						string userInput = Console.ReadLine();
						userChoice = game.ValidateUserChoice(userInput);
						if (userChoice == Choice.invalid)
						{
							Console.WriteLine("Hey, buddy... that wasn't a 1 or 2 or 3!");
						}
					} while (userChoice == Choice.invalid);

					// get the computers choice
					computerChoice = game.GetComputerChoice();
					Console.WriteLine($"The computers choice is {computerChoice}");
					Player roundWinner = game.PlayRound(computerChoice,userChoice);
					//have this try catch for when there is no round winner and the Fname/Lname lfields are NULL.
                    try
                    {
						Console.WriteLine($"The winner of this round is {roundWinner.Fname} {roundWinner.Lname}");
					}
					catch (SystemException ex)
                    {
						Console.WriteLine($"Congrats! This is the SystemException class. => {ex.Message}");
					}
					catch (Exception ex)
                    {
						Console.WriteLine($"An unknown exception was thrown in Program.cs try/catch => {ex.Message}");
                    }
					//the finally block ALWAYS runs!!!
      //              finally
      //              {
						//Console.WriteLine("This is the finally block");
      //              }
				}

				Player gameWinner = game.WinnerYet();

				Console.WriteLine($"The game is over.");
				//Game currentGame = game.currentGame;

				Console.WriteLine($"The computer won {game.GetComputerWins()} games.");
				Console.WriteLine($"You won {game.GetUserWins()} games.");
				Console.WriteLine($"There were {game.GetTies()} ties.");
				Console.WriteLine($"This game was {game.GetNumRounds()} rounds long..");
				Console.WriteLine($"Would you like to play again?\nEnter no is you don't want to play again.\nOtherwise, do anything else.");
				string playAgainInput = Console.ReadLine();
				
                if (playAgainInput.ToLower().Equals("no"))//method chaining
                {
					playAgain = false;
                }
			} while (playAgain);
		}//EoMain


	}//EoC
}//EoN
