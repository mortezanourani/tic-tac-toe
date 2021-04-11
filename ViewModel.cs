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
        private const string UserName = "Mortiza";
        private const string UserSymbol = "X";
        private const string ComputerName = "Computer";
        private const string ComputerSymbol = "O";
        #endregion

        #region Properties
        private Gameboard _GameBoard;
        public Gameboard GameBoard
        {
            get { return _GameBoard;  }
            set { _GameBoard = value; propertyChanged(); }
        }
        #endregion

        private Player User;
        private Player Computer;

        public void Initialzie()
        {
            User = new Player(UserName, UserSymbol);
            Computer = new Player(ComputerName, ComputerSymbol);

            GameBoard = new Gameboard();
        }

        public void Play(int CellNumber)
        {
            if (GameBoard.IsGameOver)
                return;

            if (!GameBoard.IsCellEmpty(CellNumber))
                return;

            GameBoard = GameBoard.Update(User, CellNumber);

            // Check If User Wins
            if (User.IsWinner())
            {
                GameBoard = GameBoard.NotifyWins(User);
                return;
            }

            // Check If Draw
            if(GameBoard.EmptyCells.Count() == 0)
            {
                GameBoard = GameBoard.NotifyDraw();
                return;
            }

            // Computer.Select();
            CellNumber = Computer.Select(GameBoard.EmptyCells);
            GameBoard = GameBoard.Update(Computer, CellNumber);

            // Check If Computer Wins
            if (Computer.IsWinner())
            {
                GameBoard = GameBoard.NotifyWins(Computer);
                return;
            }
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
