using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.VehicleServices
{
    public interface IVehicleService
    {
        Task<bool> CreateVehicle(VehicleCreate model);
        Task<bool> UpdateVehicle(VehicleEdit model);
        Task<bool> DeleteVehicle(int id);
        Task<VehicleDetail> GetVehicleById(int id);
        Task<List<VehicleListItem>> GetAllVehicles();
    }
}
