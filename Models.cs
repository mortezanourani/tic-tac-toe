using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        #region Fields
        public string Name;
        public string Symbol;
        public int[] Selects = new int[] { };

        public string WinningMessage;

        private List<int[]> WinnerSets = new List<int[]>()
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 3, 6, 9 },
            new int[] { 1, 5, 9 },
            new int[] { 3, 5, 7 }
        };
        #endregion

        public Player(string playerName, string playerSymbol)
        {
            Name = playerName;
            Symbol = playerSymbol;
        }

        public int Select(int[] PossibleMoves)
        {
            Random Rand = new Random();
            int indx = Rand.Next(PossibleMoves.Length);

            List<int> Temp = new List<int>();
            foreach (int TempItem in this.Selects)
            {
                Temp.Add(TempItem);
            }
            Temp.Add(PossibleMoves[indx]);
            this.Selects = Temp.ToArray();
            return PossibleMoves[indx];
        }

        public bool IsWinner()
        {
            if (WinnerSets.Any(WinnerSet => WinnerSet.All(Select => this.Selects.Contains(Select)))) return true;
            return false;
        }
    }

    public class Gameboard
    {
        #region Properties
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
        #endregion

        #region Fields
        public bool IsGameOver;
        public int[] EmptyCells = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        #endregion

        #region Constants
        private const string WinMessage = "{0} Wins!";
        private const string DrawMessage = "No one wins, so Draw!";
        #endregion

        #region Methods
        public bool IsCellEmpty(int CellNumber)
        {
            return this.EmptyCells.Contains(CellNumber);
        }

        public Gameboard Update(Player Player, int CellNumber)
        {
            // Update Player's selected cells list
            List<int> Temp = new List<int>();
            foreach (int TempItem in Player.Selects)
            {
                Temp.Add(TempItem);
            }
            Temp.Add(CellNumber);
            Player.Selects = Temp.ToArray();

            // Update Gameboard's empty cells list
            Temp.Clear();
            foreach(int Cell in this.EmptyCells)
            {
                if (Cell == CellNumber) continue;
                Temp.Add(Cell);
            }
            this.EmptyCells = Temp.ToArray();

            string Symbol = Player.Symbol;
            switch (CellNumber)
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
        #endregion
        public Gameboard NotifyWins(Player Winner)
        {
            this.IsGameOver = true;
            this.Message = string.Format(WinMessage, Winner.Name);
            return this;
        }

        public Gameboard NotifyDraw()
        {
            this.IsGameOver = true;
            this.Message = DrawMessage;
            return this;
        }
    }
}
