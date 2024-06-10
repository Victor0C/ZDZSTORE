using Microsoft.EntityFrameworkCore;
using ZDZSTORE.database;
using ZDZSTORE.Sale.Model;

namespace ZDZSTORE.Sale
{
    public class SaleRepository
    {
        private DataContext _context;

        public SaleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<SaleModel?> GetOne(string id)
        {
            SaleModel? sale = await _context.Sales
                .Include(s => s.items)
                .FirstOrDefaultAsync(s => s.id == id);

            return sale;
        }

        public async Task<IEnumerable<SaleModel>> GetAll()
        {
            IEnumerable<SaleModel> sale = await _context.Sales
                .Include(s => s.items)
                .ToListAsync();

            return sale;
        }

        public async Task<SaleModel> CreateOne(SaleModel sale)
        {
            _context.Sales.Add(sale);
            await this.Update();

            return sale;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOne(SaleModel sale)
        {
            _context.Remove(sale);
            await this.Update();
        }
    }
}
