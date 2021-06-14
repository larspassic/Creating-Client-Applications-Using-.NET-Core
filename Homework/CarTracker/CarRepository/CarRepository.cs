using System;
using System.Collections.Generic;
using System.Text;
using CarDB;
using System.Linq;

namespace CarRepository
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Nickname { get; set; }
        public int Mileage { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
    public class CarRepository
    {
        
        //Looks like an "Add" method
        public CarModel Add(CarModel carsModel)
        {
            //Convert the CarsModel that was sent in via parameter to a DbModel?
            //
            var carDb = ToDbModel(carsModel);

            //Add the carDb variable to the "Added" entity state
            DatabaseManager.Instance.Car.Add(carDb);

            //Save changes
            DatabaseManager.Instance.SaveChanges();

            carsModel = new CarModel
            {
                Id = carDb.CarId,
                Make = carDb.CarMake,
                Model = carDb.CarModel,
                ModelYear = carDb.CarModelYear,
                Color = carDb.CarColor,
                Type = carDb.CarType,
                Nickname = carDb.CarNickname,
                Mileage = carDb.CarMileage,
                Notes = carDb.CarNotes,
                CreatedDate = carDb.CarCreatedDate,
            };

            return carsModel;
        }

        //Looks like a "Get All" method
        //Looks like a CarsModel object called items is being made
        //Using a Linq query stored in an object called t
        public List<CarModel> GetAll()
        {
            var items = DatabaseManager.Instance.Car.Select(t => new CarModel 
            { 
                Id = t.CarId,
                Make = t.CarMake,
                Model = t.CarModel,
                ModelYear = t.CarModelYear,
                Color = t.CarColor,
                Type = t.CarType,
                Nickname = t.CarNickname,
                Mileage = t.CarMileage,
                Notes = t.CarNotes,
                CreatedDate = t.CarCreatedDate,

            }).ToList();
            
            return items;
        }

        //Looks like a method to update an...object?
        public bool Update(CarModel carsModel)
        {
            //Do a lookup on the CarId to get the CURRENT version of that object
            var original = DatabaseManager.Instance.Car.Find(carsModel.Id);

            if (original != null) //if the original is not empty
            {
                //What does this do?
                //Looks like it finds the original/current version of the object that was passed in as a parameter
                //And sets it to the new version of the object that was passed in as a parameter
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(carsModel));

                //Description says "Saves all changes made in this context to the database"
                //That is cool.
                DatabaseManager.Instance.SaveChanges();

                return true;
            }
            
            //Should this be else return false?
            return false;
        }

        //Method to remove an item from the database
        public bool Remove(int carId)
        {
            //Use the DatabaseManager to search for the item where the CarId matches
            //The carId that was sent in via parameter
            var items = DatabaseManager.Instance.Car.Where(t => t.CarId == carId);

            if (items.Count() == 0)
            {
                return false; //Send failure boolean if there was nothing there
            }

            DatabaseManager.Instance.Car.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();
            return true;
        }

        //What does this do?
        //Takes a model and turns it in to an actual object?
        private Car ToDbModel(CarModel carsModel)
        {
            //Create a Car object
            var carDb = new Car
            {
                
                CarId = carsModel.Id,
                CarMake = carsModel.Make,
                CarModel = carsModel.Model,
                CarModelYear = carsModel.ModelYear,
                CarColor = carsModel.Color,
                CarType = carsModel.Type,
                CarNickname = carsModel.Nickname,
                CarMileage = carsModel.Mileage,
                CarNotes = carsModel.Notes,
                CarCreatedDate = carsModel.CreatedDate
            };

            return carDb;
        }
    }
}
