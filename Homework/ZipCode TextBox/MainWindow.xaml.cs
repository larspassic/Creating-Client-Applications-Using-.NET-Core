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
            //Code to validate Zip Codes goes here
        }

        //Event handler for when submit button is clicked.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Pop up a message box to show that the user was successful.
            MessageBox.Show($"You submitted a valid US or Canadian Zip Code!");
        }
    }
}
