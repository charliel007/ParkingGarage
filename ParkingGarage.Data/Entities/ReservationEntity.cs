using ParkingGarage.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Data.Entities
{
    public class ReservationEntity
    {
        public int Id { get; set; }
        public ReservationType ReservationType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ?IssuedNumber { get; set; }
        public int VehicleLocationEntityId { get; set; }
        public virtual VehicleLocationEntity VehicleLocationEntity { get; set; }
    }
}
