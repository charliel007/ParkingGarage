using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkingGarage.Data.Entities;
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
            CheckUser();

            ClaimsPrincipal currentUser = this.User;
            string id = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(await _vehicleService.GetAllVehicles(id));
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            VehicleCreate rCreate = new VehicleCreate();

            CheckUser();

            return View(rCreate);
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(VehicleCreate vehicle)
        {
            //Assign current UserId to vehicle and remove from property from modelstate for validation purpose
            ClaimsPrincipal currentUser = this.User;
            vehicle.UserEntityId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ModelState.Remove("UserEntityId");

            if (!ModelState.IsValid)
                return BadRequest(vehicle);
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
 
        //method to make sure a user is logged in
        public IActionResult CheckUser()
        {
            ClaimsPrincipal currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated == false)
                return BadRequest("Need to be logged in.");
            else
            return View();
        }

    }
}
