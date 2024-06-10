using NanoidDotNet;
using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Product.DTO
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "The name field is required.")]
        [MaxLength(64, ErrorMessage = "The name field must have a maximum of 64 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public int amount { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public int price { get; set; }
    }
}
