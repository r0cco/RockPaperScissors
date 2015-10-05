﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;
using RockPaperScissors.Implementations;

namespace RockPaperScissors
{
    public class Game
    {
        public void PlayRound()
        {
            Player p1 = new WeightedComputerPlayer("Player1");
            Player p2 = new WeightedComputerPlayer("Player2");

            MatchResult result = new MatchResult();
            result.Player1_Choice = p1.GetChoice();
            result.Player2_Choice = p2.GetChoice();

            if (result.Player1_Choice == result.Player2_Choice)
            {
                result.Match_Result = Result.Tie;
            }
            else if ((result.Player1_Choice == Choice.Rock && result.Player2_Choice == Choice.Scissors) ||
                     (result.Player1_Choice == Choice.Paper && result.Player2_Choice == Choice.Rock) ||
                     (result.Player1_Choice == Choice.Scissors && result.Player2_Choice == Choice.Paper))
            {
                result.Match_Result = Result.Win;
            }
            else
            {
                result.Match_Result = Result.Loss;
            }

            ProcessResult(p1, p2, result);

        }

        public void ProcessResult(Player Player1, Player Player2, MatchResult Result)
        {
            Console.WriteLine("\n{0} picked {1}, {2} picked {3}", Player1.Name,
                Enum.GetName(typeof (Choice), Result.Player1_Choice), Player2.Name,
                Enum.GetName(typeof (Choice), Result.Player2_Choice));

            switch (Result.Match_Result)
            {
                case Enums.Result.Win:
                    Console.WriteLine("\n{0} wins!!", Player1.Name);
                    break;

                case Enums.Result.Loss:
                    Console.WriteLine("\n{0} wins!!", Player2.Name);
                    break;

                default:
                    Console.WriteLine("\nYou both tie!!");
                    break;
            }
        }
    }
}
