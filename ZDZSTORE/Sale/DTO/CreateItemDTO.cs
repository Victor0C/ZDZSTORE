using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Sale.DTO
{
    public class CreateItemDTO
    {
        [Required(ErrorMessage = "The productID field is required.")]
        [StringLength(21, MinimumLength = 21, ErrorMessage = "Ivalid productID")]
        public string productID { get; set; }

        [Required(ErrorMessage = "The amount field is required.")]
        public int amount { get; set; }
    }
}
