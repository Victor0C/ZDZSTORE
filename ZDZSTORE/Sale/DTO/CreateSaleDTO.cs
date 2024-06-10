using System.ComponentModel.DataAnnotations;
using ZDZSTORE.Validations;

namespace ZDZSTORE.Sale.DTO
{
    public class CreateSaleDTO
    {
        [Required(ErrorMessage = "The userID field is required.")]
        [StringLength(21, MinimumLength = 21, ErrorMessage = "Ivalid userID")]
        public string userID { get; set; }

        [Required(ErrorMessage = "The customerCPF field is required.")]
        [Range(10000000000, 99999999999, ErrorMessage = "The customerCPF field must have exactly 11 digits.")]
        public long customerCPF { get; set; }

        [Required(ErrorMessage = "The items collection is required and cannot be empty.")]
        [NonEmptyCollection(ErrorMessage = "The list of items cannot be empty.")]
        public ICollection<CreateItemDTO> items { get; set; }
    }
}
