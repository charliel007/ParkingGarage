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
        Task<ReservationDetail> GetReservationById(int id);
        Task<List<ReservationListItem>> GetAllReservations();
    }
}
