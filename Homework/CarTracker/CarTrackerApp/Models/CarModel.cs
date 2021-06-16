using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrackerApp.Models
{
    //This class appears to convert in and out of CarModel and CarRepository.CarModel
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


        //Create a CarRepository.CarModel object
        //And set all of those properties of this model
        //To be properties in the repository model
        //Essentially this is turning a CarModel object into a CarRepository.CarModel object
        public CarRepository.CarModel ToRepositoryModel()
        {
            
            var repositoryModel = new CarRepository.CarModel
            {
                //The objects on the left are the CarRepository.CarModel objects
                //The objects on the right are the CarModel objects
                Id = Id,
                Make = Make,
                Model = Model,
                ModelYear = ModelYear,
                Color = Color,
                Type = Type,
                Nickname = Nickname,
                Mileage = Mileage,
                Notes = Notes,
                CreatedDate = CreatedDate
            };

            return repositoryModel;
        }

        //And it looks like this is taking CarRepository.CarModel and converting it in to a CarModel
        public static CarModel ToModel(CarRepository.CarModel repositoryModel)
        {
            var carModel = new CarModel
            {
                Id = repositoryModel.Id,
                Make = repositoryModel.Make,
                Model = repositoryModel.Model,
                ModelYear = repositoryModel.ModelYear,
                Color = repositoryModel.Color,
                Type = repositoryModel.Type,
                Nickname = repositoryModel.Nickname,
                Mileage = repositoryModel.Mileage,
                Notes = repositoryModel.Notes,
                CreatedDate = repositoryModel.CreatedDate
            };

            return carModel;
        }

        internal CarModel Clone()
        {
            return (CarModel)this.MemberwiseClone();
        }
    }

}
