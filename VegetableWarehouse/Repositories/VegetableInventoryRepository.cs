using LocalDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegetableWarehouse.Models;
using VegetableWarehouse.Repositories.Models;

namespace VegetableWarehouse.Repositories
{
    public class VegetableInventoryRepository
    {
        private readonly DBContext _context;
        public VegetableInventoryRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<int> AddVegetable(VegetableRequestModel model)
        {
            var item = new Vegetable
            {
                Name = model.Name,
                Price = model.Price
            };

            _context.Vegetables.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<Vegetable> GetVegetable(int id)
        {
            return await _context.Vegetables.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Vegetable>> ListVegetables()
        {
            return await _context.Vegetables.ToArrayAsync();
        }


        public async Task<int> UpdateVegetable(VegetableRequestUpdateModel request)
        {
            var item = _context.Vegetables.SingleOrDefault(x => x.Id == request.Id);
            if (item != null)
            {
                item.Name = request.Name;
                item.Price = request.Price;
                await _context.SaveChangesAsync();
                return item.Id;
            }
            return 0;
        }


        public async Task<int> DeleteVegetable(int id)
        {
            var item = _context.Vegetables.FirstOrDefault(x => x.Id == id);
            _context.Vegetables.Remove(item);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
