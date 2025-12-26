using System.ComponentModel.DataAnnotations;

namespace RoutingDemo.Controllers
{
    public class UserProfile
    {
        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in 123-456-7890 format.")]
        public string PhoneNumber { get; set; }
    }
}
