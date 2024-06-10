using NanoidDotNet;
using System.ComponentModel.DataAnnotations;
using ZDZSTORE.Sale.Model;

namespace ZDZSTORE.Product.Model
{
    public class ProductModel
    {
        [Key]
        [Required]
        [MaxLength(21)]
        public string id { get; set; } = Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

        [Required]
        [MaxLength(64)]
        public string name { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public int price { get; set; }

        public virtual ICollection<ItemModel> items { get; set; } = new List<ItemModel>();
    }
}
