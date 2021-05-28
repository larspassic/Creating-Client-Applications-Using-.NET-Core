using System;
using AutoMapper;
using System.ComponentModel; //Added this during data validation lab on 5/27/2021

namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        //Begin section for data validation lab


        //What are these - fields?
        private string nameError { get; set; }
        private string emailError { get; set; }

        //INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            else if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                    
                        //Add other cases as needed?
                    case "Email":
                        {
                            //Setting the... property??
                            EmailError = "";

                            if (Email == null || string.IsNullOrEmpty(Email))
                            {
                                EmailError = "Email cannot be empty.";
                            }
                            else if (Email.Length > 20)
                            {
                                EmailError = "Email cannot be longer than 20 characters.";
                            }

                            return emailError;
                        }
                }

                return null;
            }
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string EmailError
        {
            get
            {
                return emailError;
            }
            set
            {
                if (emailError != value)
                {
                    emailError = value;
                    OnPropertyChanged("EmailError");
                }
            }
        }

        //End of the validation code


        internal ContactModel Clone()
        {
            return(ContactModel)this.MemberwiseClone();
        }

        // Exercise 2 - Automapper Configuration
        private static readonly MapperConfiguration

            config = new MapperConfiguration(cfg => cfg.CreateMap<ContactRepository.ContactModel, ContactModel > ().ReverseMap());

        private static IMapper mapper = config.CreateMapper();

        //Use the mapper
        public ContactRepository.ContactModel ToRepositoryModel()
        {
            //Exercise 2 under delete - do not call field by field
            /*
                var repositoryModel = new ContactRepository.ContactModel
                {
                    Age = Age,
                    CreatedDate = CreatedDate,
                    Email = Email,
                    Id = Id,
                    Name = Name,
                    Notes = Notes,
                    PhoneNumber = PhoneNumber,
                    PhoneType = PhoneType
                };
            */


            var repositoryModel = mapper.Map<ContactRepository.ContactModel > (this);

            return repositoryModel;
        }

        public static ContactModel ToModel(ContactRepository.ContactModel repositoryModel)
        {

            /*

                var contactModel = new ContactModel
                {
                    Age = respositoryModel.Age,
                    CreatedDate = respositoryModel.CreatedDate,
                    Email = respositoryModel.Email,
                    Id = respositoryModel.Id,
                    Name = respositoryModel.Name,
                    Notes = respositoryModel.Notes,
                    PhoneNumber = respositoryModel.PhoneNumber,
                    PhoneType = respositoryModel.PhoneType
                };

            */


            var contactModel = mapper.Map<ContactModel>(repositoryModel);

            return contactModel;
        }


    }
}