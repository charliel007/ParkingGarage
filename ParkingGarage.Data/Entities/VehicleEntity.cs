using ParkingGarage.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Data.Entities
{
    public class VehicleEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string ?Make { get; set; }
        public string ?Model { get; set; }
        public Color Color { get; set; }
        public LicensePlateState LicensePlateState { get; set; }
        public string ?LicensePlateNumber{ get; set; }
        public List<VehicleLocationEntity> VehicleLocations { get; set; } = new List<VehicleLocationEntity>();
        public int UserEntityId { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}
