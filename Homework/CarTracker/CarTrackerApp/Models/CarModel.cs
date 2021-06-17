using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CarTrackerApp.Models
{
    //This class appears to convert in and out of CarModel and CarRepository.CarModel
    public class CarModel : IDataErrorInfo, INotifyPropertyChanged
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

        //These are fields
        private string makeError { get; set; }
        private string modelError { get; set; }
        private string modelYearError { get; set; }

        //INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


        //IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Make":
                        {
                            MakeError = "";

                            if (Make == null || string.IsNullOrEmpty(Make))
                            {
                                MakeError = "Make cannot be empty.";
                                
                            }
                            else if (Make.Length > 50)
                            {
                                MakeError = "Make cannot be longer than 50 characters.";
                            }

                            return MakeError;
                        }
                    case "Model":
                        {
                            ModelError = "";

                            if (Model == null || string.IsNullOrEmpty(Model))
                            {
                                ModelError = "Model cannot be empty.";
                            }
                            else if (Model.Length > 50)
                            {
                                ModelError = "Model cannot be longer than 50 characters.";
                            }
                            return ModelError;
                        }
                    case "ModelYear":
                        {
                            ModelYearError = "";

                            if (ModelYear.ToString().Length != 4)
                            {
                                ModelYearError = "Please enter 4 digits for model year.";
                            }
                            else if (ModelYear == 0 || ModelYear > 2600 || ModelYear < 1900)
                            {
                                ModelYearError = "Model year must be between 1900 and 2600.";
                            }

                            return ModelYearError;
                        }
                }
                return null;
            }
        }

        //This is a property aka "accessor"
        public string MakeError
        {
            get
            {
                return makeError;
            }
            set
            {
                if(makeError != value)
                {
                    makeError = value;
                    
                    OnPropertyChanged("MakeError");
                }
            }
        }

        public string ModelError
        {
            get
            {
                return modelError;
            }
            set
            {
                if (modelError != value)
                {
                    modelError = value;
                    OnPropertyChanged("ModelError");
                }

            }
        }

        public string ModelYearError
        {
            get
            {
                return modelYearError;

            }
            set
            {
                if(modelYearError != value)
                {
                    modelYearError = value;
                    OnPropertyChanged("ModelYearError");
                }
            }
        }

        //End of the validation code
        

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
