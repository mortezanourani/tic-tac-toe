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
    }
}
