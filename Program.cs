using HomeWork_.TicTacToeGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HomeWork_.TicTacToeGame
{   
    
    class Program
    {
        private static readonly TicTacToeGame Game = new TicTacToeGame();
        static void Main(string[] args) 
        {
            Console.WriteLine(GetPrintState());
            while (Game.GetWinner() == Winner.GameIsNotOver)
            {
                int index = int.Parse(Console.ReadLine());
                Console.Clear();
                Game.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintState());

            }
            Console.WriteLine($"Победа {Game.GetWinner()}");
        }                      
        static string GetPrintState()
        {
            var state = new StringBuilder();
            for (int i = 1; i <= 7; i += 3)
            {
                state.AppendLine("     |     |     |")
                     .AppendLine($"  {GetPrintChar(i)}  |  {GetPrintChar(i + 1)}  |  {GetPrintChar(i + 2)}  |")
                     .AppendLine("_____|_____|_____|");
            }
            return state.ToString();
        }
        static string GetPrintChar(int index)
        {
            State state = Game.GetState(index);
            if (state == State.Unset)
            {
                return index.ToString();
            }
            return state == State.Cross ? "X" : "O";
        }      
        
    }
}





