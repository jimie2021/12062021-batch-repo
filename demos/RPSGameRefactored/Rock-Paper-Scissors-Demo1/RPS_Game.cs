using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1
{
    internal interface RPS_Game
    {
        Choice ValidateUserChoice(string choice);
        Choice GetComputerChoice();
        Player PlayRound(Choice p1Choice, Choice P2Choice);
        Player WinnerYet();


    }
}
