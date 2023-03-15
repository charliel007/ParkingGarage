using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using ParkingGarage.Data.Entities;
using ParkingGarage.Data.Entities.Enums;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Services.ReservationServices;
using ParkingGarage.Services.VehicleServices;
using System.Security.Claims;

namespace ParkingGarage.MVC.Controllers
{
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private IReservationService _reservationService;
        private IVehicleService _vehicleService;
        public ReservationController(IReservationService reservationService, IVehicleService vehicleService)
        {
            _reservationService = reservationService;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;

            //check if user is logged in.
            if (currentUser.Identity.IsAuthenticated == false)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            string id = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            //***check if user has entered any vehicles***..  Need vehicle Dependency Injection
            var vehDatabase = await _vehicleService.GetAllVehicles(id);
            if (vehDatabase.Count == 0)
                return RedirectToAction("Index","Vehicle");

            return View(await _reservationService.GetAllReservations(id));
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            ClaimsPrincipal currentUser = this.User;
            string id = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var locationOptions = await _reservationService.SelectLocationListItemConversion();
            var vehicleOptions = await _reservationService.SelectVehicleListItemConversion(id);
            
            ReservationCreate rCreate = new ReservationCreate();
           
            rCreate.LocationOptions = locationOptions;
            rCreate.VehicleOptions = vehicleOptions;

            int count = vehicleOptions.Count();
            if (count == 0) return BadRequest("You must enter a Vehicle to make a Reservation");

            return View(rCreate);
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(ReservationCreate reservation, decimal hours, decimal days, decimal years)
        {

            if ((hours > 0 || days > 0) && years > 0)
            {
                return RedirectToAction(nameof(Post));
            }
            if ((hours > 0 || days > 0) && (reservation.ReservationType == ReservationType.Permit))
            {
                return RedirectToAction(nameof(Post));
            }
            if (years > 0 && (reservation.ReservationType == ReservationType.Pass))
            {
                return RedirectToAction(nameof(Post));
            }

            int hrconvert = Convert.ToInt32((years * 8760) + (days * 24) + hours);
            reservation.ExpirationDate = reservation.IssueDate
            .AddHours(hrconvert);

            ModelState.Remove("hours");
            ModelState.Remove("days");
            ModelState.Remove("years");

            //check to see how many spots are available and not exceed the limit
            var countedTimes = await _reservationService.GetForCompare();

            int count = 0;
            int spot = 0;

            foreach (var existingRes in countedTimes)  
            {
                if((reservation.IssueDate <= existingRes.ExpirationDate) && (existingRes.IssueDate <= reservation.ExpirationDate))
                {
                    count += 1;
                }
            }

            var location = countedTimes.Select(i => i.VehicleLocation.Location)
                .Where(l => l.Id == reservation.LocationEntityId).FirstOrDefault();

            if (location != null)
            {
                spot = location.Spot;
                if (count >= spot) return BadRequest("The Parking Garage is Full During that Time.  Try a Much Later Date!");
            }

            if (!ModelState.IsValid) return BadRequest(reservation);
            if (await _reservationService.CreateReservation(reservation))
                return RedirectToAction(nameof(Index));
            else
            return View(reservation);
        }
    }
}
