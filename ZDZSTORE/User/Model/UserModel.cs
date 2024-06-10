using NanoidDotNet;
using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.User.Model
{
    public class UserModel
    {
        [Key]
        [Required]
        [MaxLength(21)]
        public string id { get; set; } = Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

        [Required]
        [MaxLength(64)]
        public string name { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
