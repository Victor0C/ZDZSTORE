using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.User.DTO
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "The name field is required.")]
        [MaxLength(64, ErrorMessage = "The name field must have a maximum of 64 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "The email field is not a valid email address.")]
        [MaxLength(100, ErrorMessage = "The email field must have a maximum of 100 characters")]
        public string email { get; set; }

        [Required]
        [MaxLength(21,ErrorMessage = "The password field must have a maximum of 21 characters")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        public string password { get; set; }

    }
}
