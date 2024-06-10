using ZDZSTORE.Product;
using ZDZSTORE.Product.Model;
using ZDZSTORE.Sale.DTO;
using ZDZSTORE.Sale.Model;

namespace ZDZSTORE.Sale
{
    public class SaleService
    {

        private ProductRepository _productRepository;

        public SaleService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task checkProducts(ICollection<CreateItemDTO> itemsDTO)
        {
            var productIDs = new HashSet<string>();

            foreach (var itemDTO in itemsDTO)
            {
                var product = await _productRepository.GetOne(itemDTO.productID);

                if (productIDs.Contains(itemDTO.productID))
                {
                    throw new ArgumentException($"Product with ID {itemDTO.productID} is duplicated in the request.");
                }
                productIDs.Add(itemDTO.productID);

                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with ID {itemDTO.productID} not found.");
                }

                if (product.amount < itemDTO.amount)
                {
                    throw new ArgumentException($"Requested quantity {itemDTO.amount} for product ID {itemDTO.productID} exceeds available stock.");
                }

            }
        }

        public async Task<BuildListItemsResult> buildListItems(ICollection<CreateItemDTO> itemsDTO)
        {
            var items = new List<ItemModel>();
            var salePrice = 0;

            foreach (var itemDTO in itemsDTO)
            {
                var product = await _productRepository.GetOne(itemDTO.productID);
                product.amount = product.amount - itemDTO.amount;

                var price = product.price * itemDTO.amount;
                salePrice = salePrice + price;

                var itemModel = new ItemModel
                {
                    productID = itemDTO.productID,
                    name = product.name,
                    amount = itemDTO.amount,
                    price = price
                };

                items.Add(itemModel);
            }

            return new BuildListItemsResult
            {
                items = items,
                salePrice = salePrice
            };
        }

        public async Task returnItems(ICollection<ItemModel> items)
        {
            foreach (var itemDTO in items)
            {
                ProductModel product = await _productRepository.GetOne(itemDTO.productID);
                product.amount = product.amount + itemDTO.amount;
            }
        }
    }
}
