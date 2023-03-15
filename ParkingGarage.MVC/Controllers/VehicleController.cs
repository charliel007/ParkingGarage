using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkingGarage.Data.Entities;
using ParkingGarage.Models.VehicleModels;
using ParkingGarage.Services.VehicleServices;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            ClaimsPrincipal currentUser = this.User;

            if (currentUser.Identity.IsAuthenticated == false)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            string id = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(await _vehicleService.GetAllVehicles(id));
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            VehicleCreate rCreate = new VehicleCreate();

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


        [HttpGet("Edit/{vehicleId}")]
        public async Task<IActionResult> Edit(int vehicleId)
        {
            //I want edit form to populate previous data
            var vehicle = await _vehicleService.GetVehicleById(vehicleId);
            // the VM -> VehicleEdit so that's what we need to pass into the View().
            VehicleEdit vehicleVM = new VehicleEdit
            {
                Id = vehicleId,
                Year = vehicle.Year,
                Make = vehicle.Make,
                ModelName = vehicle.ModelName,
                Color = vehicle.Color,
                LicensePlateState = vehicle.LicensePlateState,
                LicensePlateNumber = vehicle.LicensePlateNumber
            };

            return View(vehicleVM);
        }

        [HttpPost("Edit/{vehicleId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int vehicleId,
            VehicleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Id = vehicleId;

            if (await _vehicleService.UpdateVehicle(model))
                return RedirectToAction("Details", new { id = vehicleId });
            else
                return RedirectToAction(nameof(Error));
        }

        [HttpGet("Delete/{vehicleId}")]
        public async Task<IActionResult> Delete(int? vehicleId)
        {
            if (vehicleId == null)
                return RedirectToAction(nameof(Index));
            
            var vehicleInDb = await _vehicleService.GetVehicleById(vehicleId.Value);

            if (vehicleInDb != null)
            {
                return View(vehicleInDb);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Delete/{vehicleId}")]
        public async Task<IActionResult> Delete(int vehicleId)
        {
            if (await _vehicleService.DeleteVehicle(vehicleId))
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Error));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}
