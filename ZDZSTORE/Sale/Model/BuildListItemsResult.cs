namespace ZDZSTORE.Sale.Model
{
    public class BuildListItemsResult
    {
        public List<ItemModel> items { get; set; }

        public long salePrice { get; set; }

        public string? productNotFound { get; set; }
    }
}
