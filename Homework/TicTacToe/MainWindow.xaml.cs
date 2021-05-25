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

        public string activePlayer = "";



        //Default constructor
        public MainWindow()
        {
            InitializeComponent();

            //Resize the app to fit the content
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;

            
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            //Set X as the first player
            activePlayer = "X";

            //Set the status bar to be the current player
            uxTurn.Text = $"Player {activePlayer}'s turn";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Make the button object
            Button button = new Button();

            //Set it to the "sender" aka the button that sent the click event
            button = (Button)sender;

            //Change the button's content to be the active player
            button.Content = activePlayer;


        }
    }
}
