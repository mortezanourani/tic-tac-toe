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

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void propertyChanged([CallerMemberName] string porpertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porpertyName));
        }
        #endregion
    }
}
