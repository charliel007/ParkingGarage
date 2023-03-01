using ParkingGarage.Data.Entities.Enums;
using ParkingGarage.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.ReservationModels
{
    public class ReservationListItem
    {
        public int Id { get; set; }
        public ReservationType ReservationType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? IssuedNumber { get; set; }
        public LocationListItem Location { get; set; }
    }
}
