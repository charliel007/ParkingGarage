using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Data.Entities.Enums;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Services.ReservationServices;

namespace ParkingGarage.MVC.Controllers
{
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _reservationService.GetAllReservations());
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            var locationOptions = await _reservationService.SelectLocationListItemConversion();
            var vehicleOptions = await _reservationService.SelectVehicleListItemConversion();
            
            ReservationCreate rCreate = new ReservationCreate();
           
            rCreate.LocationOptions = locationOptions;
            rCreate.VehicleOptions = vehicleOptions;
            
            return View(rCreate);
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(ReservationCreate reservation)
        {
            if (!ModelState.IsValid) return BadRequest(reservation);
            if (await _reservationService.CreateReservation(reservation))
                return RedirectToAction(nameof(Index));
            else
            return View(reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _reservationService.GetReservationById(id));
        }

    }
}
