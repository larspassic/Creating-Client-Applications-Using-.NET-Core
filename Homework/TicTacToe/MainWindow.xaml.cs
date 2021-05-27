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

            var gameBoard = createGameBoard();

            foreach (Button squareButton in gameBoard)
            {
                squareButton.IsEnabled = false;
            }

        }

        private List<Button> createGameBoard()
        {
            //Maybe pull in all of the button elements and their tags and make a list object?
            List<Button> gameBoard = new List<Button>();

            gameBoard.AddRange(uxGrid.Children.OfType<Button>());

            //gameBoard cheat sheet:
            //gameBoard[0] = 0,0
            //gameBoard[1] = 0,1
            //gameBoard[2] = 0,2
            //gameBoard[3] = 1,0
            //gameBoard[4] = 1,1
            //gameBoard[5] = 1,2
            //gameBoard[6] = 2,0
            //gameBoard[7] = 2,1
            //gameBoard[8] = 2,2

            return gameBoard;
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            //Set X as the first player
            activePlayer = "X";

            //Create a gameBoard object to interact with all of the buttons
            var gameBoard = createGameBoard();

            //Loop through all of the buttons and do some tasks
            foreach (Button squareButton in gameBoard)
            {
                squareButton.Content = null; //Clear out the content of the buttons
                squareButton.IsEnabled = true; //Enable the buttons because we're starting a new game
            }

            //Refresh the status bar
            RefreshStatusBar();
        }

        private void CheckForWinners()
        {

        }

        private void RefreshStatusBar()
        {
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
            if (button.Content == null) //Only make a turn if the button doesn't have a player in it
            {
                button.Content = activePlayer;
                
                //Since we successfully made a move, change to the next player
                if (activePlayer == "X")
                {
                    activePlayer = "O";
                }
                else if (activePlayer == "O")
                {
                    activePlayer = "X";
                }

                //Also update the status bar
                RefreshStatusBar();
            }
            

        }
    }
}
