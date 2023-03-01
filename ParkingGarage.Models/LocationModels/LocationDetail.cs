using ParkingGarage.Data.Entities;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Models.VehicleLocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.LocationModels
{
    public class LocationDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Spot { get; set; }
        public List<ReservationListItem> Reservations { get; set; }
        public List<VehicleLocationListItem> VehicleLocations { get; set; }
    }
}
