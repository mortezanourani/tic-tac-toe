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
            User = new Player("Mortiza", "X");
            Computer = new Player("Computer", "O");

            GameBoard = new Gameboard();
        }

        private bool IsCellEmpty(int Cell)
        {
            return GameBoard.EmptyCells.Contains(Cell);
        }

        public void Play(int SelectedCell)
        {
            if (!IsCellEmpty(SelectedCell))
                return;

            User.Select(SelectedCell);

            GameBoard = GameBoard.Update(SelectedCell, User.Symbol);

            if (User.IsWinner())
                GameBoard = GameBoard.Update(string.Format("{0} Wins!", User.Name));

            SelectedCell = Computer.Select(GameBoard.EmptyCells);
            GameBoard = GameBoard.Update(SelectedCell, Computer.Symbol);

            if (User.IsWinner())
                GameBoard = GameBoard.Update(string.Format("{0} Wins!", Computer.Name));
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
