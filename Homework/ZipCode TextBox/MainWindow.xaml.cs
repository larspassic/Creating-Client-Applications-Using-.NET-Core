using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

//Assignment 04
//Author: Passic, Lars, 2011958

namespace ZipCode_TextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Event handler for every time text inside the text box is changed.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Code to validate Zip Codes goes here - ready, begin!

            //Pull string in from text box
            string textBoxContents = TextBoxZipCode.Text;

            //Create some variables to track progress
            bool usZipCodeFound;
            bool canZipCodeFound;

            //Store the results of the actual checks
            usZipCodeFound = CheckForUSZipCode(textBoxContents);
            canZipCodeFound = CheckForCanZipCode(textBoxContents);

            //Actually act on the test results
            //Code for if a Zip code was found
            if (usZipCodeFound || canZipCodeFound == true)
            {
                //If there was a previous attempt, the error message may still be showing
                //Since Zip Code was found and we are successful now, need to disable it
                TextBlockErrorMessage.Visibility = System.Windows.Visibility.Hidden;
                
                //Enable the button
                ButtonSubmit.IsEnabled = true;

                //Since Zip Code was found, we need to show the success message
                TextBlockSuccessMessage.Visibility = System.Windows.Visibility.Visible;

                if (usZipCodeFound) //If US Zip found - show US message
                {
                    TextBlockSuccessMessage.Text = "We have detected a valid US Zip Code";
                }
                else if (canZipCodeFound) //If Candian code found - show Canada message
                {
                    TextBlockSuccessMessage.Text = "We have detected a valid Canadian Postal Code";
                }

            }
            //Code for if a Zip code was NOT found - from either the US method or the CAN method
            else if (usZipCodeFound == false && canZipCodeFound == false)
            {
                //Since Zip code was not found, need to make the error message visible
                TextBlockErrorMessage.Visibility = System.Windows.Visibility.Visible;

                //Since Zip code was not found, need to hide the success message
                TextBlockSuccessMessage.Visibility = System.Windows.Visibility.Hidden;

                //If there was previously a valid Zip, the submit button may have been enabled
                //Since Zip code was not found, need to disable the submit button
                ButtonSubmit.IsEnabled = false;
            }

        }

        private bool CheckForCanZipCode(string textBoxContents)
        {
            //Create a string to hold the regex pattern for Canadian postal codes
            string canZipPattern = @"^[A-Z]\d[A-Z]\d[A-Z]\d$";

            //Create the Regex object out of the string
            Regex canRegex = new Regex(canZipPattern);

            //Return the reuslts of the match
            return canRegex.IsMatch(textBoxContents);
        }

        private bool CheckForUSZipCode(string textBoxContents)
        {
            //Create a string to hold the regex pattern for US zip codes
            string usZipPattern = @"^\d{5}$|^\d{5}-\d{4}$";

            //Create the Regex object out of the string
            Regex usRegex = new Regex(usZipPattern);

            //Return the results of the match
            return usRegex.IsMatch(textBoxContents);
        }

        //Event handler for when submit button is clicked.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Pop up a message box to show that the user was successful.
            MessageBox.Show($"You submitted a valid US Zip Code or Canadian Postal Code!","Success!");
        }
    }
}
