using NanoidDotNet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.Sale.Model
{
    public class SaleModel
    {
        [Key]
        [Required]
        [MaxLength(21)]
        public string id { get; set; } = Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

        [Required]
        [MaxLength(21)]
        public string userID { get; set; }

        [ForeignKey("userID")]
        public virtual UserModel user { get; set; }

        [Required]
        [Range(10000000000, 99999999999)]
        public long customerCPF { get; set; }

        [Required]
        public long price { get; set; }
    }
}
