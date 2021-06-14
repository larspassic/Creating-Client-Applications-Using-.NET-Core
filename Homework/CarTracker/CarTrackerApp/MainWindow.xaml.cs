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

                //OR
                //App.CarRepository.Add(window.Car.ToRepositoryModel());
            }
        }
    }
}
