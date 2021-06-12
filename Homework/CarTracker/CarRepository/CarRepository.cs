using System;
using System.Collections.Generic;
using System.Text;
using CarDB;
using System.Linq;

namespace CarRepository
{
    public class CarsModel
    {
        public int CarId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarModelYear { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public string CarNickname { get; set; }
        public int CarMileage { get; set; }
        public string CarNotes { get; set; }
        public DateTime CarCreatedDate { get; set; }
    }
    
    public class CarRepository
    {
        
        //Looks like an "Add" method
        public CarsModel Add(CarsModel carsModel)
        {
            //Need to finish this
            return carsModel;
        }

        //Looks like a "Get All" method
        public List<CarsModel> GetAll()
        {
            var items = DatabaseManager.Instance.Car.Select(t => new CarsModel 
            { 
            //Need to finish this
            }).ToList();
            
            return items;
        }

        //Looks like a method to update an...object?
        public bool Update(CarsModel carsModel)
        {
            //Need to finish this
        }

        public bool Remove(int carId)
        {
            //Need to finish this
        }

        private Car ToDbModel(CarsModel carsModel)
        {
            //Need to finish this
        }
    }
}
