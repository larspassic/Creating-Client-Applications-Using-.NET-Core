using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Birthday_Card_Generator.Models
{
    public class BirthdayCardInput
    {
        //Fields
        
        [Required(ErrorMessage ="FROM: field is required.")]
        public string from { get; set; }

        [Required(ErrorMessage ="TO: field is required.")]
        public string to { get; set; }

        [Required(ErrorMessage ="MESSAGE: field is required.")]
        public string message { get; set; }



    }
}
