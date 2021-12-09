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
				int convertedNumber = -1;
				bool conversionBool = false;
				int computerWins = 0;   //how many rounds the computer has won
				int userWins = 0;       //how many rounds the user has won
				int tieRound = 0;       //how many tie rounds
				int round = 1;          //the nuimebr of roiunds played
										//get input form the user
				Console.WriteLine("Hello. Welcome to Rock-Paper-Scissors Game!");
				Console.WriteLine("What is your Name?");
				string userName = Console.ReadLine();

				//loop here till one player has won 2
				while (computerWins < 2 && userWins < 2)
				{
					//get user choice and validate
					do
					{
						Console.WriteLine("Please enter enter 1 for ROCK, 2 for PAPER, 3 for SCISSORS.\n");
						string userInput = Console.ReadLine();

						//this version of TryParse() takes a string and the second argument is an out variable that is instantiated in that moment.
						conversionBool = Int32.TryParse(userInput, out convertedNumber);
						if (!conversionBool || convertedNumber < 1 || convertedNumber > 3)
						{
							Console.WriteLine("Hey, buddy... that wasn't a 1 or 2 or 3!");
						}
					} while (!(convertedNumber > 0 && convertedNumber < 4));
					/**homework - 
					 * 1. get a random number for the computer
					 * 2. compare who won the round
					 * 3. refactor the code to have a first to two wins game
					 * 4. print out the winner, and how many games were won by each (and ties)
					 * 5. exit the program.
					**/

					Random randNum = new Random();
					int computerChoice = randNum.Next(1, 4);// inclusive of the first (lower) value and exclusive of hte second(upper) value. 
					Console.WriteLine($"The computers choice is {computerChoice}");
					if ((computerChoice == 1 && convertedNumber == 2) || (computerChoice == 2 && convertedNumber == 3) || (computerChoice == 3 && convertedNumber == 1))
					{
						Console.WriteLine("You won this round.\n");
						userWins++;
					}
					else if (computerChoice == convertedNumber)
					{
						Console.WriteLine("This round was a tie.\n");
						tieRound++;
					}
					else
					{
						Console.WriteLine("The computer won this round.\n");
						computerWins++;
					}

					if (computerWins >= 2 || userWins >= 2)
					{
						break;
					}
					round++;
				}

				Console.WriteLine($"The game is over.");
				Console.WriteLine($"The computer won {computerWins} games.");
				Console.WriteLine($"You won {userWins} games.");
				Console.WriteLine($"There were {tieRound} ties.");
				Console.WriteLine($"This game was {round} rounds long..");
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
