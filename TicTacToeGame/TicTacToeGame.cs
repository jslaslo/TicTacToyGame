using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_.TicTacToeGame
{
    enum State
    {
        Unset,
        Cross,
        Zero
    }
    public enum Winner
    {
        Crosses,
        Zero,
        Draw,
        GameIsNotOver
    }
    class TicTacToeGame
    {
        private readonly State[] field = new State[9];
        public int StrokeCounter { get; private set; }

        public TicTacToeGame()
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = State.Unset;
            }
        }
        public void MakeMove(int index)
        {
            field[index - 1] = StrokeCounter % 2 == 0 ? State.Cross : State.Zero;

            StrokeCounter++;
        }
        public State GetState(int index)
        {
            return field[index - 1];
        }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9,
                             1, 2, 3, 4, 5, 6, 7, 8, 9,
                             1, 5, 9, 3, 5, 7);
        }
        public Winner GetWinner(params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i += 3)
            {
                bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
                if (same)
                {
                    State state = GetState(indexes[i]);
                    if (state != State.Unset)
                    {
                        return state == State.Cross ? Winner.Crosses : Winner.Zero;
                    }
                }
            }
            if (StrokeCounter < 9)
            {
                return Winner.GameIsNotOver;
            }
            return Winner.Draw;
        }
        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }
}
