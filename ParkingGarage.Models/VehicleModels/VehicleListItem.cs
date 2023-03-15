using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.VehicleModels
{
    public class VehicleListItem
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? ModelName { get; set; }
        public string? LicensePlateNumber { get; set; }
    }
}
