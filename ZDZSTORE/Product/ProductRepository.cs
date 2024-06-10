using Microsoft.EntityFrameworkCore;
using ZDZSTORE.database;
using ZDZSTORE.Product.Model;

namespace ZDZSTORE.Product
{
    public class ProductRepository
    {
        private DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductModel?> GetOne(string id)
        {
            ProductModel? product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            IEnumerable<ProductModel> product = await _context.Products.ToListAsync();

            return product;
        }

        public async Task<ProductModel> CreateOne(ProductModel product)
        {
            _context.Products.Add(product);
            await this.Update();

            return product;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOne(ProductModel product)
        {
            _context.Remove(product);
            await this.Update();
        }
    }
}
