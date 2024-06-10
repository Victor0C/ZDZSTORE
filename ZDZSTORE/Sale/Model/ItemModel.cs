using NanoidDotNet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZDZSTORE.Product.Model;

namespace ZDZSTORE.Sale.Model
{
    public class ItemModel
    {
        [Key]
        [Required]
        [MaxLength(21)]
        public string id { get; set; } = Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

        [Required]
        [MaxLength(21)]
        public string productID { get; set; }

        [ForeignKey("productID")]
        public virtual ProductModel product { get; set; }

        [Required]
        [MaxLength(21)]
        public string saleID { get; set; }

        [ForeignKey("saleID")]
        public virtual SaleModel sale { get; set; }

        [Required]
        [MaxLength(64)]
        public string name { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public long price { get; set; }
    }
}
