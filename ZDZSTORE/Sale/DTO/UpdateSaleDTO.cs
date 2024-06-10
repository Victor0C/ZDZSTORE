using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Sale.DTO
{
    public class UpdateSaleDTO
    {

        [Range(10000000000, 99999999999, ErrorMessage = "The customerCPF field must have exactly 11 digits.")]
        public long customerCPF { get; set; }

        public long price { get; set; }
    }
}
