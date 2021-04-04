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
        private GameBoard _gameBoard = new GameBoard();
        public GameBoard gameBoard
        {
            get { return _gameBoard;  }
            set { _gameBoard = value; propertyChanged(); }
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void propertyChanged([CallerMemberName] string porpertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porpertyName));
        }
        #endregion
    }
}
