using ParkingGarage.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.LocationServices
{
    public interface ILocationService
    {
        Task<List<LocationListItem>> GetAllLocations();
    }
}
