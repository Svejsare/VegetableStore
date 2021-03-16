using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VegetableWarehouse.Models;
using VegetableWarehouse.Services;

namespace VegetableWarehouse.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VegetableInventoryController : ControllerBase
    {
        private readonly VegetableInventoryService _viService;

        public VegetableInventoryController(VegetableInventoryService viService)
        {
            _viService = viService;
        }

        [HttpPost]
        public ActionResult<int> AddVegetable(VegetableRequestModel request)
        {
            return Ok(_viService.AddVegetable(request));
        }

        [HttpGet]
        public ActionResult<VegetableViewModel> GetVegetable(int id)
        {
            return Ok(_viService.GetVegetable(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<VegetableViewModel>> ListVegetables()
        {
            return Ok(_viService.ListVegetables());
        }


        [HttpPost]
        public ActionResult<int> UpdateVegetable(VegetableRequestUpdateModel request)
        {
            return Ok(_viService.UpdateVegetable(request));
        }

        [HttpPost]
        public ActionResult<int> DeleteVegetable(int id)
        {
            return Ok(_viService.DeleteVegetable(id));
        }
    }
}
