using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarTrackerApp.Models;

namespace CarTrackerApp
{
    /// <summary>
    /// Interaction logic for CarDetailsWindow.xaml
    /// </summary>
    public partial class CarDetailsWindow : Window
    {
        public CarDetailsWindow()
        {
            InitializeComponent();

            //Hide the popup window from the Windows Taskbar
            ShowInTaskbar = false;

        }

        public CarModel Car { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Need help with this
            //At first, this method created a "new entry"
            //But then we modified the app to either create a new entry, or modify an existing entry
            //We used to use the code below to create the new entry
            //But then we started using bindings in the XAML
            //And we commented all of this out.
            
            //Car = new CarModel();
            //Car.Make = uxMake.Text;
            //Car.Model = uxModel.Text;
            //Car.ModelYear = int.Parse(uxModelYear.Text);
            //Car.Color = uxColor.Text;
            //Car.Nickname = uxNickName.Text;
            //Car.Mileage = int.Parse(uxMileage.Text.Trim());
            //Car.Notes = uxNotes.Text;
            ////Trying to add car status here
            //Car.CreatedDate = DateTime.Now;
            
            if (uxCar.IsChecked.Value)
            {
                Car.Type = "Car";
            }
            else if (uxTruck.IsChecked.Value)
            {
                Car.Type = "Truck";
            }
            else if (uxSUV.IsChecked.Value)
            {
                Car.Type = "SUV";
            }

            //This is the return value of ShowDialog() below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            //This is the return value of ShowDialog() below
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Car != null)
            {
                if (Car.Type == "Car")
                {
                    uxCar.IsChecked = true;
                }
                else if (Car.Type == "Truck")
                {
                    uxTruck.IsChecked = true;
                }
                else if (Car.Type == "SUV")
                {
                    uxSUV.IsChecked = true;
                }
                uxSubmit.Content = "Save";
                this.Title = "Edit Car";

            }
            else
            {
                Car = new CarModel();
                Car.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Car;
        }
    }
}
