using System;
using System.Collections.Generic;

namespace CarDB
{
    public partial class Car
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

        //public string CarStatus1 { get; set; }
    }
}
