using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models


{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        
        //Exercise 1 - guest response email exercise
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "RSVP is required")]
        public bool? WillAttend { get; set; }
    }
}