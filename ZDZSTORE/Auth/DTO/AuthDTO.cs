using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Auth.DTO
{
    public class AuthDTO
    {
        [Required(ErrorMessage = "The email field is required.")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        public string password { get; set; }
    }
}
