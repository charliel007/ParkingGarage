using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<bool> CreateReservation(ReservationCreate model);
        Task<List<ReservationListItem>> GetForCompare();
        Task<List<ReservationListItem>> GetAllReservations(string id);
        Task<IEnumerable<SelectListItem>> SelectLocationListItemConversion();
        Task<IEnumerable<SelectListItem>> SelectVehicleListItemConversion(string id);
    }
}
