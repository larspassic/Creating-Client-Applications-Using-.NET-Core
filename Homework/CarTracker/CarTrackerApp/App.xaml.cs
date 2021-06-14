using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarTrackerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Accessor for CarRepository


        //First create a private static field
        private static CarRepository.CarRepository carRepository;


        //Not sure what this is
        static App()
        {
            carRepository = new CarRepository.CarRepository();
        }

        //Create a public property called CarRepository?
        public static CarRepository.CarRepository CarRepository
        {
            get
            {
                //Return the private static field from above
                return carRepository;
            }
        }
    }
}
