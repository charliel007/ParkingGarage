using ParkingGarage.Data.Entities;
using ParkingGarage.Models.LocationModels;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.VehicleLocationModels
{
    public class VehicleLocationListItem
    {
        public int Id { get; set; }
        public int LocationEntityId { get; set; }
        public int VehicleEntityId { get; set; }
        public LocationListItem Location { get; set; }
        public VehicleListItem Vehicle  { get; set; }
        public List<ReservationListItem> Reservations { get; set; } = new List<ReservationListItem>();

    }
}
