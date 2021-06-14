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
            Car = new CarModel();

            Car.Make = uxMake.Text;
            Car.Model = uxModel.Text;
            Car.ModelYear = int.Parse(uxModelYear.Text);
            Car.Color = uxColor.Text;
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
            Car.Nickname = uxNickName.Text;
            Car.Mileage = int.Parse(uxMileage.Text);
            Car.Notes = uxNotes.Text;
            Car.CreatedDate = DateTime.Now;

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
    }
}
