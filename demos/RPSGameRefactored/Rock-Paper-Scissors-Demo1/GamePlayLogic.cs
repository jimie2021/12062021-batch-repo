using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1
{
    internal class GamePlayLogic : RPS_Game
    {
        List<Player> players;// all the registered players
        List<Game> games;// all the played games
        Random randNum;
        internal Game game;

        //constructor
        public GamePlayLogic()
        {
            players = new List<Player>();
        }
        // overload constructor that is called as the first constructor or the first game after compilation
        public GamePlayLogic(string fname, string lname)
        {
            randNum = new Random();// get the random generator working
            //create a enw player based on the names.. after varifying that the player doesn't already exist.
            this.players = new List<Player>();// the new player
            Player computer = new Player("Max","HeadRoom");
            this.game = new Game();// the current game
            Player player = new Player(fname, lname);//create a new player
            this.players.Add(player);// add the new player to the list of players
            game.Player1 = computer;
            game.Player2 = player;
        }
        
        /// <summary>
        /// This method validates the choice that the user made adn that 
        /// it is a 1, 2, or 3..
        /// returns Choice.invalid if not.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        internal Choice ValidateUserChoice(string choice)
        {
            int convertedNumber = -1;
            bool conversionBool = false;
            conversionBool = Int32.TryParse(choice, out convertedNumber);
            if (!conversionBool || convertedNumber < 1 || convertedNumber > 3)
            {
                return Choice.invalid;
            }
            return (Choice)convertedNumber;
        } 

        internal Choice GetComputerChoice()
        {
            Choice computerChoice = (Choice)randNum.Next(1, 4);// inclusive of the first (lower) value and exclusive of hte second(upper) value. 
            return computerChoice;
        }


        /// <summary>
        /// this method will take the choices of the 2 players, 
        /// create a new round, 
        /// evaluate the choices,
        /// and determine if a winner has prevailed.
        /// </summary>
        /// <param name="p1Choice"></param>
        /// <param name="P2Choice"></param>
        internal Player PlayRound(Choice p1Choice, Choice P2Choice)
        {
            //create a round
            Round round = new Round();
            round.Player1 = game.Player1;//assign the correct players to the round
            round.Player2 = game.Player2;
            game.Rounds.Add(round);

            if (((int)p1Choice == 1 && P2Choice == Choice.Paper) || 
                ((int)p1Choice == 2 && P2Choice == Choice.Scissors) || 
                ((int)p1Choice == 3 && P2Choice == Choice.Rock))
            {
                round.Winner = round.Player2;
                return round.Winner;
                // Console.WriteLine("You won this round.\n");
            }
            else if (p1Choice == P2Choice)
            {
                //Console.WriteLine("This round was a tie.\n");
                return null;
            }
            else
            {
                //Console.WriteLine("The computer won this round.\n");
                round.Winner = round.Player1;
                return round.Winner;
            }
        }

        /// <summary>
        /// THis method iterates over game.Rounds to see is ther is a winner yet.
        /// </summary>
        /// <returns></returns>
        internal Player WinnerYet()
        {
            //iterate over hte Rounds List while keeping track of who won each round
            if (game.Rounds.Count <2) return null;
            int p1RoundWins = 0;
            int p2RoundWins = 0;

            foreach (Round r in game.Rounds)
            {
                if(r.Winner == game.Player1)p1RoundWins++;
                if (r.Winner == game.Player2) p2RoundWins++;
            }
            if (p1RoundWins == 2) return game.Player1;
            if (p2RoundWins == 2) return game.Player2;
            return null;
        }








    }//EoC
}//EoN
