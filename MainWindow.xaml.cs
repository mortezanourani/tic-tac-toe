using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel MainViewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel;
            MainViewModel.Initialzie();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            string UsreMove = ((Button)sender).Tag.ToString();
            int selectedRow = Int32.Parse(UsreMove.Substring(0, 1));
            int selectedColumn = Int32.Parse(UsreMove.Substring(1, 1));
            MainViewModel.Play(selectedRow, selectedColumn);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Initialzie();
        }
    }
}
