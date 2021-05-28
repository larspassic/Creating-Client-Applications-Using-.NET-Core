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
        public bool gameIsWon = false;
        public bool allSquaresTaken = false;

        //Default constructor
        public MainWindow()
        {
            InitializeComponent();

            //Resize the app to fit the button content
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;

            uxGrid.HorizontalAlignment = HorizontalAlignment.Center;
            uxGrid.VerticalAlignment = VerticalAlignment.Center;
            //uxGrid.Height = 200;
            //uxGrid.Width = 200;

            var gameBoard = CreateGameBoard();

            foreach (Button squareButton in gameBoard)
            {
                squareButton.IsEnabled = false; //Start the app with all of the buttons disabled
                squareButton.Content = "";
            }

        }


        private void CheckForWinners()
        {
            //Create an object that is the current player for comparison
            string currentPlayerPattern = $"{activePlayer}{activePlayer}{activePlayer}";

            //Bring in the game board
            var gameBoard = CreateGameBoard();

            //Create a jagged array of arrays of ints to hold victory patterns
            int[][] patterns = new int[8][];

            //Victory patterns
            //See "cheat sheet" for game board locations
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

            patterns[0] = new int[3] { 0, 1, 2 };
            patterns[1] = new int[3] { 3, 4, 5 };
            patterns[2] = new int[3] { 6, 7, 8 };
            patterns[3] = new int[3] { 0, 3, 6 };
            patterns[4] = new int[3] { 1, 4, 7 };
            patterns[5] = new int[3] { 2, 5, 8 };
            patterns[6] = new int[3] { 0, 4, 8 };
            patterns[7] = new int[3] { 2, 4, 6 };

            
            //Loop that will pull data in from the board, check for winners, and update gameIsWon if someone wins
            for (int i = 0; i < patterns.Length; i++)
            {
                //Part 1 gets the data from gameBoard and builds a string ie. "XXX"
                string tempString = gameBoard[patterns[i][0]].Content.ToString() + gameBoard[patterns[i][1]].Content.ToString() + gameBoard[patterns[i][2]].Content.ToString();

                //compare the newly created string with the currentPlayerPattern
                //If the player won, return true
                if (currentPlayerPattern == tempString)
                {
                    //Take actions if a winner was found
                    gameIsWon = true;
                    RefreshStatusBar();
                }
            }

            //If the game is won - disable all of the buttons
            if(gameIsWon == true)
            {
                foreach (Button squareButton in gameBoard)
                {
                    squareButton.IsEnabled = false;
                }
            }

        }

        private List<Button> CreateGameBoard()
        {
            //Maybe pull in all of the button elements and their tags and make a list object?
            List<Button> gameBoard = new List<Button>();

            gameBoard.AddRange(uxGrid.Children.OfType<Button>());

            return gameBoard;
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            //Set X as the first player
            activePlayer = "X";

            //New game
            gameIsWon = false;

            //Create a gameBoard object to interact with all of the buttons
            var gameBoard = CreateGameBoard();

            //Loop through all of the buttons and do some tasks
            foreach (Button squareButton in gameBoard)
            {
                squareButton.Content = null; //Clear out the content of the buttons
                squareButton.IsEnabled = true; //Enable the buttons because we're starting a new game
                squareButton.Content = "";
            }

            //Refresh the status bar
            RefreshStatusBar();
        }



        private void RefreshStatusBar()
        {
            if (gameIsWon == true)
            {
                uxTurn.Text = $"Player {activePlayer} won!!!";

            }
            else
            {
                //Set the status bar to be the current player
                uxTurn.Text = $"Player {activePlayer}'s turn";
            }
            var gameBoard = CreateGameBoard();
            //Create a list of button objects to hold remaining unplayed squares
            List<Button> remainingSquares = new List<Button>();

            foreach (Button buttonSquare in gameBoard) //This loop is looking for any remaining unplayed board spaces
            {

                if ((string)buttonSquare.Content == "") //If there is a square with "" in the content, that means it has not been used yet
                {
                    remainingSquares.Add(buttonSquare); //Add that button to the list
                }
            }

            if (remainingSquares.Count == 0) //If we looped through the game board and there was no squares left, cat's game
            {
                foreach (Button squareButton in gameBoard)
                {
                    squareButton.IsEnabled = false; //Disable all of the buttons because cat's game
                    uxTurn.Text = $"Cat's game!";
                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); //Quit the app?
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Make the button object
            Button button = new Button();

            //Set it to the "sender" aka the button that sent the click event
            button = (Button)sender;

            //Change the button's content to be the active player
            if (button.Content.ToString() == "") //Only allow click if the button is empty
            {
                button.Content = activePlayer;

                //Check for winners
                CheckForWinners();

                //First check to see if the game is over yet
                if (gameIsWon == false)
                {
                    //Since we successfully made a move, change turns to the next player
                    if (activePlayer == "X")
                    {
                        activePlayer = "O";
                    }
                    else if (activePlayer == "O")
                    {
                        activePlayer = "X";
                    }
                }
                

            }
            


            //Also update the status bar, since there is a possibility that we switched turns
            RefreshStatusBar();


        }
    }
}
