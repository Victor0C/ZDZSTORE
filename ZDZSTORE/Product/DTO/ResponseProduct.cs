using NanoidDotNet;
using System.ComponentModel.DataAnnotations;

namespace ZDZSTORE.Product.DTO
{
    public class ResponseProduct
    {
        public string id { get; set; } 

        public string name { get; set; }

        public int amount { get; set; }

        public int price { get; set; }
    }
}
