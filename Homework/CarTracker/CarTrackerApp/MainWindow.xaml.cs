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
using CarTrackerApp.Models;

namespace CarTrackerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RefreshMainView();

            uxMainCarList.SelectedValue = null;
        }

        
        //"Tomorrow if I don't want to use XAML anymore..."


        private void RefreshMainView()
        {
            var cars = App.CarRepository.GetAll();

            //uxMainCarList.ItemsSource = cars.Select(t => CarModel.ToModel(t)).ToList();

            //Going with the alternate method to do this
            var uiCarModelList = new List<CarModel>();

            foreach (var repositoryCarModel in cars)
            {
                var uiCarModel = CarModel.ToModel(repositoryCarModel);
                
                uiCarModelList.Add(uiCarModel);
            }

            //Set the main listview object's items source to be the object we just finished creating
            uxMainCarList.ItemsSource = uiCarModelList;


            //Trying to update the status bar
            //uxStatusBar
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new CarDetailsWindow();

            if (window.ShowDialog() == true)
            {
                //Create a variable for the car model?
                var uiCarModel = window.Car;

                //Use our converter to convert the CarModel to a RepositoryCarModel
                var repositoryCarModel = uiCarModel.ToRepositoryModel();

                App.CarRepository.Add(repositoryCarModel);

                RefreshMainView();
                //OR
                //App.CarRepository.Add(window.Car.ToRepositoryModel());
            }
        }

        private void uxFileEdit_Click(object sender, RoutedEventArgs e)
        {
            var window = new CarDetailsWindow();

            window.Car = selectedCar.Clone();

            if (window.ShowDialog() == true)
            {
                App.CarRepository.Update(window.Car.ToRepositoryModel());
                RefreshMainView();
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.CarRepository.Remove(selectedCar.Id);
            selectedCar = null;
            RefreshMainView();
        }

        //Create the variable to hold the selected object
        private CarModel selectedCar;

        private void uxMainCarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Set the selected car to be the "selected value" of the main listview element
            selectedCar = (CarModel)uxMainCarList.SelectedValue;
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedCar != null);
            uxContextFileDelete.IsEnabled = (selectedCar != null);

        }

        private void uxFileEdit_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileEdit.IsEnabled = (selectedCar != null);
            uxContextFileEdit.IsEnabled = (selectedCar != null);
        }

        private void uxMainCarList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            uxFileEdit_Click(sender, null);
        }
    }
}
