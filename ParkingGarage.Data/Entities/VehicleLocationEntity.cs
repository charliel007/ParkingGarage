using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Data.Entities
{
    public class VehicleLocationEntity
    {
        public int Id { get; set; }
        public int LocationEntityId { get; set; }
        public int VehicleEntityId { get; set; }
    }
}
