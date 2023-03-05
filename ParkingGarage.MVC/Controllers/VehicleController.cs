using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Models.VehicleModels;
using ParkingGarage.Services.VehicleServices;
using System.Security.Claims;

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

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            VehicleCreate rCreate = new VehicleCreate();

            ClaimsPrincipal currentUser = this.User;

            if (currentUser.Identity.IsAuthenticated == false)
            return BadRequest("Need to be logged in.");

            return View(rCreate);
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(VehicleCreate vehicle)
        {
            ClaimsPrincipal currentUser = this.User;
            vehicle.UserEntityId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var test = vehicle;

            // if (!ModelState.IsValid)
            //    return BadRequest(vehicle);
            if (await _vehicleService.CreateVehicle(vehicle))
                return RedirectToAction(nameof(Index));
            else
                return View(vehicle);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _vehicleService.GetVehicleById(id));
        }
    }
}
