using ParkingGarage.Models.VehicleLocationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.VehicleLocationServices
{
    public interface IVehicleLocationService
    {
        Task<bool> CreateVehicleLocation(VehicleLocationCreate model);
        Task<List<VehicleLocationListItem>> GetAllVehicleLocations();
    }
}
