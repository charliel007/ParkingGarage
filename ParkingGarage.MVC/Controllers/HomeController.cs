using Microsoft.AspNetCore.Mvc;
using ParkingGarage.MVC.Models;
using ParkingGarage.Services.LocationServices;
using System.Diagnostics;

namespace ParkingGarage.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ILocationService _locationService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _locationService.GetAllLocations());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}