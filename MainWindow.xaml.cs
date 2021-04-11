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
            int CellNumber = Int32.Parse(((Button)sender).Tag.ToString());
            MainViewModel.Play(CellNumber);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Initialzie();
        }
    }
}
