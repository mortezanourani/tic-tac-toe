using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string Name;
        public string Symbol;
        public int[] Selects = new int[] { };

        public Player(string playerName, string playerSymbol)
        {
            Name = playerName;
            Symbol = playerSymbol;
        }

        public int Select(int[] PossibleMoves)
        {
            Random Rand = new Random();
            int indx = Rand.Next(PossibleMoves.Length);
            return PossibleMoves[indx];
        }

        public void Select(int SelectedCell)
        {
            List<int> Temp = new List<int>();
            foreach (int TempItem in this.Selects)
            {
                Temp.Add(TempItem);
            }
            Temp.Add(SelectedCell);
            this.Selects = Temp.ToArray();
            return;
        }

        public bool IsWinner()
        {
            // If selects contains any of winning sets retrun true
            return true;
        }
    }

    public class Gameboard
    {
        public string Cell1 { get; set; }
        public string Cell2 { get; set; }
        public string Cell3 { get; set; }
        public string Cell4 { get; set; }
        public string Cell5 { get; set; }
        public string Cell6 { get; set; }
        public string Cell7 { get; set; }
        public string Cell8 { get; set; }
        public string Cell9 { get; set; }

        public string Message { get; set; }

        public int[] EmptyCells = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Gameboard Update(int Position, string Symbol)
        {
            List<int> Temp = new List<int>();
            foreach(int Cell in this.EmptyCells)
            {
                if (Cell == Position) continue;
                Temp.Add(Cell);
            }
            this.EmptyCells = Temp.ToArray();

            switch (Position)
            {
                case 1:
                    this.Cell1 = Symbol;
                    break;
                case 2:
                    this.Cell2 = Symbol;
                    break;
                case 3:
                    this.Cell3 = Symbol;
                    break;
                case 4:
                    this.Cell4 = Symbol;
                    break;
                case 5:
                    this.Cell5 = Symbol;
                    break;
                case 6:
                    this.Cell6 = Symbol;
                    break;
                case 7:
                    this.Cell7 = Symbol;
                    break;
                case 8:
                    this.Cell8 = Symbol;
                    break;
                case 9:
                    this.Cell9 = Symbol;
                    break;
            }

            return this;
        }

        public Gameboard Update(string Message)
        {
            this.Message = Message;
            return this;
        }
    }
}
