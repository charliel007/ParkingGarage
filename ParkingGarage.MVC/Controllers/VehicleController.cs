using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Services.VehicleServices;

namespace ParkingGarage.MVC.Controllers
{
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _vehicleService.GetAllVehicles());
        }
    }
}
