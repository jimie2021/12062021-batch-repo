using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1
{
    public class GamePlayLogic : RPS_Game
    {
        List<Player> players;// all the registered players
        List<Game> games;// all the played games
        Random randNum;
        private Game currentGame;
        private Player currentLoggedInPlayer;

        //constructor
        public GamePlayLogic()
        {
            players = new List<Player>();
            games = new List<Game>();
            randNum = new Random(); 
        }
        // overload constructor that is called as the first constructor or the first game after compilation
        public GamePlayLogic(string fname, string lname)
        {
            randNum = new Random();// get the random generator working
            //create a enw player based on the names.. after varifying that the player doesn't already exist.
            this.players = new List<Player>();// the new player
            Player computer = new Player("Max","HeadRoom");
            this.currentGame = new Game();// the current game
            Player player = new Player(fname, lname);//create a new player
            this.players.Add(player);// add the new player to the list of players
            currentGame.Player1 = computer;
            currentGame.Player2 = player;
        }

        /// <summary>
        /// This method will see if the loggin in user already exists
        /// if so, will assign that player to currentLoggedInPlayer
        /// if not, will create a new player and assign that player to currentLoggedInPlayer
        /// </summary>
        /// <param name="userFName"></param>
        /// <param name="userLName"></param>
        internal void Login(string userFName, string userLName)
        {
            //throw new NotImplementedException("Hey, dinkus... make a body for game.login()");
           
            //foreach (Player p in players)
            //{
            //    if (p.Fname == userFName && p.Lname == userLName)
            //    {
            //        this.currentLoggedInPlayer = p;
            //    }
            //}

            Player p = players.Where(p => p.Fname == userFName && p.Lname == userLName).FirstOrDefault();
            
            if (p == null)
            {
                Player p1 = new Player(userFName, userLName);
                this.currentLoggedInPlayer = p1;
                players.Add(p1);
            }
        }

        /// <summary>
        /// This method validates the choice that the user made adn that 
        /// it is a 1, 2, or 3..
        /// returns Choice.invalid if not.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public Choice ValidateUserChoice(string choice)
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

        public Choice GetComputerChoice()
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
        /// <param name="p2Choice"></param>
        public Player PlayRound(Choice p1Choice, Choice p2Choice)
        {
            //create a round
            Round round = new Round();
            round.Player1 = currentGame.Player1;//assign the correct players to the round
            round.Player2 = currentGame.Player2;
            round.P1Choice = p1Choice;
            round.P2Choice = p2Choice;
            currentGame.Rounds.Add(round);

            if (((int)p1Choice == 1 && p2Choice == Choice.Paper) || 
                ((int)p1Choice == 2 && p2Choice == Choice.Scissors) || 
                ((int)p1Choice == 3 && p2Choice == Choice.Rock))
            {
                round.Winner = round.Player2;
                return round.Winner;
                // Console.WriteLine("You won this round.\n");
            }
            else if (p1Choice == p2Choice)
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
        public Player WinnerYet()
        {
            //iterate over hte Rounds List while keeping track of who won each round
            if (currentGame.Rounds.Count <2) return null;
            int p1RoundWins = 0;
            int p2RoundWins = 0;

            foreach (Round r in currentGame.Rounds)
            {
                if(r.Winner == currentGame.Player1)p1RoundWins++;
                if (r.Winner == currentGame.Player2) p2RoundWins++;
            }
            if (p1RoundWins == 2) return currentGame.Player1;
            if (p2RoundWins == 2) return currentGame.Player2;
            return null;
        }

        /// <summary>
        /// This method returns how many rounds the computer won.
        /// </summary>
        /// <returns></returns>
        internal int GetComputerWins()
        {
            int compWins = 0;
            foreach (Round r in currentGame.Rounds)
            {
                if (r.Winner == r.Player1)
                {
                    compWins++;
                }
            }
            return compWins;

        }

        /// <summary>
        /// This method returns how many rounds the user won.
        /// </summary>
        /// <returns></returns>
        internal int GetUserWins()
        {
            int userWins = 0;
            foreach (Round r in currentGame.Rounds)
            {
                if (r.Winner == r.Player2)
                {
                    userWins++;
                }
            }
            return userWins;
        }

        /// <summary>
        /// This method returns how many rounds were a tie.
        /// </summary>
        /// <returns></returns>
        internal int GetTies()
        {
            int ties = 0;
            foreach (Round r in currentGame.Rounds)
            {
                if (r.Winner == null)
                {
                    ties++;
                }
            }
            return ties;
        }

        /// <summary>
        /// This method returns how many rounds wer played in the current, completed, game
        /// </summary>
        /// <returns></returns>
        internal int GetNumRounds()
        {
            return currentGame.Rounds.Count;
        }









    }//EoC
}//EoN
