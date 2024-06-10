using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Product.DTO
{
    public class UpdateProductDTO
    {
        [MaxLength(64, ErrorMessage = "The name field must have a maximum of 64 characters")]
        public string name { get; set; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "The price field must be a valid integer.")]
        public int amount { get; set; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "The price field must be a valid integer.")]
        public int price { get; set; }
    }
}
