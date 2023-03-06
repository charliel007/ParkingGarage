using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Data.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Address { get; set; }
        public string ?City { get; set; }
        public int Spot { get; set; }
        public List<VehicleLocationEntity> VehicleLocations { get; set; } = new List<VehicleLocationEntity>();

    }
}
