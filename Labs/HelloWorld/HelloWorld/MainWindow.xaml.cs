﻿using System;
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
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        
        public MainWindow()
        {
            InitializeComponent();
            //this.WindowState = WindowState.Maximized;

            //Old way
            //uxName.DataContext = user;
            //uxNameError.DataContext = user;

            uxContainer.DataContext = user;

            var sample = new SampleContext();
            sample.User.Load();
            var users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Submitting password: {uxPassword.Text}");

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckForCharacters();
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckForCharacters();
        }

        private void CheckForCharacters()
        {
            //Check if both uxPassword and uxName have something in them, if so, enable the button
            if (uxName.Text != "" && uxPassword.Text != "")
            {
                this.uxSubmit.IsEnabled = true;
            }
            
            //Else if statement to turn the button off
            else if (uxName.Text == "" || uxPassword.Text == "")
            {
                this.uxSubmit.IsEnabled = false;
            }
        }
    }
}
