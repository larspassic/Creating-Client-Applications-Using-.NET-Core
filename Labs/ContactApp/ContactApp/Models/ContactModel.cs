using System;
using AutoMapper;

namespace ContactApp.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

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