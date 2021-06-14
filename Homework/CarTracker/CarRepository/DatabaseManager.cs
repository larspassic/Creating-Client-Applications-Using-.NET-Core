using System;
using System.Collections.Generic;
using System.Text;
using CarDB;

namespace CarRepository
{
    class DatabaseManager
    {
        //Create a field called entities
        private static readonly CarsContext entities;

        //Initialize and open the database connection
        //I think this is a constructor
        static DatabaseManager()
        {
            entities = new CarsContext();
        }

        //Provide an accessor to the database
        public static CarsContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
