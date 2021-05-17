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
            if (usZipCodeFound || canZipCodeFound)
            {
                //If there was a previous attempt, the error message may still be showing
                //Since Zip Code was found and we are successful now, need to disable it
                TextBlockErrorMessage.IsEnabled = false;
                
                //Enable the button
                ButtonSubmit.IsEnabled = true;


            }
            //Code for if a Zip code was NOT found
            if (usZipCodeFound && canZipCodeFound == false)
            {
                //Since Zip code was not found, need to enable the error message
                TextBlockErrorMessage.IsEnabled = true;

                //If there was previously a valid Zip, the submit button may have been enabled
                //Since Zip code was not found, need to disable the submit button
                ButtonSubmit.IsEnabled = false;
            }

        }

        private bool CheckForCanZipCode(string textBoxContents)
        {
            throw new NotImplementedException();
        }

        private bool CheckForUSZipCode(string textBoxContents)
        {
            throw new NotImplementedException();
        }

        //Event handler for when submit button is clicked.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Pop up a message box to show that the user was successful.
            MessageBox.Show($"You submitted a valid US or Canadian Zip Code!");
        }
    }
}
