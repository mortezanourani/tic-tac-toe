using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    internal class ViewModel : INotifyPropertyChanged
    {
        #region Fields
        private const string USER_SYMBOL = "X";
        private const string AI_SYMBOL = "O";

        private const int INCOMPLETE = 2;
        private const int USER_WON = 1;
        private const int AI_WON = -1;
        private const int TOE = 0;

        private const string TOE_MESSAGE = "No Winner!";
        private const string AI_WON_MESSAGE = "You Lose!";
        private const string USER_WON_MESSAGE = "You Won!";
        #endregion

        #region Properties
        private string[][] _GameBoard;
        public string[][] GameBoard
        {
            get { return _GameBoard; }
            set { _GameBoard = value; propertyChanged(); }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; propertyChanged(); }
        }
        #endregion

        private bool IsCellEmpty(int Row, int Column)
        {
            return string.IsNullOrWhiteSpace(GameBoard[Row][Column]);
        }

        private bool isWinner(string playerSymbol)
        {
            // Check Rows
            if (GameBoard.Any(Row => Row.All(Cell => Cell == playerSymbol)))
                return true;

            // Check Columns
            for(int i = 0; i <= 2; i++)
                if (GameBoard.All(Row => Row[i] == playerSymbol))
                    return true;

            // Check Diagonals
            string[][] Diagonals = new string[2][] { new string[3], new string[3] };
            for(int i = 0; i <= 2; i++)
            {
                Diagonals[0][i] = GameBoard[i][i];
                Diagonals[1][i] = GameBoard[i][2 - i];
            }
            if (Diagonals.Any(Diagonal => Diagonal.All(Cell => Cell == playerSymbol)))
                return true;

            return false;
        }

        private int getState()
        {
            // Check if user won
            if (isWinner(USER_SYMBOL))
                return USER_WON;

            // Check if AI won
            if (isWinner(AI_SYMBOL))
                return AI_WON;

            if (GameBoard.Any(Row => Row.Contains(string.Empty)))
                return INCOMPLETE;

            return TOE;
        }
        
        private void updateGameBoard()
        {
            GameBoard = GameBoard;

            switch (getState())
            {
                case (TOE):
                    Message = TOE_MESSAGE;
                    break;
                case (AI_WON):
                    Message = AI_WON_MESSAGE;
                    break;
                case (USER_WON):
                    Message = USER_WON_MESSAGE;
                    break;
            }

            return;
        }

        public void Initialzie()
        {
            GameBoard = new string[][]
            {
                new string[] { "", "", "" },
                new string[] { "", "", "" },
                new string[] { "", "", "" }
            };

            Message = string.Empty;
        }

        private void aiChoice(out int Row, out int Column)
        {
            List<int> Free = new List<int>();
            for (int r = 0; r <= 2; r++)
                for (int c = 0; c <= 2; c++)
                    if (string.IsNullOrWhiteSpace(GameBoard[r][c]))
                    {
                        Free.Add(r * 3 + c);
                    }
            Random Rand = new Random();
            int indx = Rand.Next(Free.Count());
            Row = Free[indx] / 3;
            Column = Free[indx] % 3;
            return;
        }

        private int aiSelect(out int Weight)
        {
            int xCount = 0;
            int oCount = 0;
            List<int> EmptyCells = new List<int>();
            for (int r = 0; r <= 2; r++)
                for (int c = 0; c <= 2; c++)
                    if (string.IsNullOrEmpty(GameBoard[r][c]))
                    {
                        EmptyCells.Add(r * 3 + c);
                    }
                    else
                    {
                        if (GameBoard[r][c] == "X")
                            xCount++;
                        if (GameBoard[r][c] == "O")
                            oCount++;
                    }

            string playerSymbol;
            if (xCount > oCount)
                playerSymbol = AI_SYMBOL;
            else
                playerSymbol = USER_SYMBOL;

            Weight = 2;
            int Best = TOE;
            int bestMove = 0;
            int nextMove = 0;
            foreach (int Cell in EmptyCells)
            {
                int r = Cell / 3;
                int c = Cell % 3;
                GameBoard[r][c] = playerSymbol;

                Weight = getState();
                if(Weight != INCOMPLETE)
                {
                    GameBoard[r][c] = "";
                    return r * 3 + c;
                }
                else
                {
                    nextMove = aiSelect(out Weight);
                    if (Weight <= Best)
                    {
                        bestMove = r * 3 + c;
                    }
                    GameBoard[r][c] = "";
                }
            }

            if (bestMove == 0)
                return EmptyCells[0];

            return bestMove;
        }

        public void Play(int CellRow, int CellColumn)
        {
            // User Turn
            if (getState() != INCOMPLETE)
                return;

            if (!IsCellEmpty(CellRow, CellColumn))
                return;

            GameBoard[CellRow][CellColumn] = USER_SYMBOL;

            updateGameBoard();

            // AI Turn
            if (getState() != INCOMPLETE)
                return;

            //aiChoice(out CellRow, out CellColumn);
            int Weight;
            int aiCell = aiSelect(out Weight);
            CellRow = aiCell / 3;
            CellColumn = aiCell % 3;

            GameBoard[CellRow][CellColumn] = AI_SYMBOL;

            updateGameBoard();
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void propertyChanged([CallerMemberName] string porpertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porpertyName));
        }
        #endregion
    }
}
