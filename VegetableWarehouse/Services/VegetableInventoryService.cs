using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegetableWarehouse.Models;
using VegetableWarehouse.Repositories;

namespace VegetableWarehouse.Services
{
    public class VegetableInventoryService
    {
        private readonly VegetableInventoryRepository _viRepsitory;

        public VegetableInventoryService(VegetableInventoryRepository viRepository)
        {
            _viRepsitory = viRepository;
        }
        public async Task<int> AddVegetable(VegetableRequestModel request)
        {
            return await _viRepsitory.AddVegetable(request);
        }

        public async Task<VegetableViewModel> GetVegetable(int id)
        {
            var veggie = await _viRepsitory.GetVegetable(id);

            return new VegetableViewModel
            {
                Id = veggie.Id,
                Name = veggie.Name,
                Price = veggie.Price
            };
        }

        public async Task<IEnumerable<VegetableViewModel>> ListVegetables()
        {
            var veggies = await _viRepsitory.ListVegetables();

            return veggies.Select(item => new VegetableViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            }).OrderBy(x => x.Id);
        }

        public async Task<int> UpdateVegetable(VegetableRequestUpdateModel request)
        {
            return await _viRepsitory.UpdateVegetable(request);
        }

        public async Task<int> DeleteVegetable(int id)
        {
            return await _viRepsitory.DeleteVegetable(id);
        }
    }
}
