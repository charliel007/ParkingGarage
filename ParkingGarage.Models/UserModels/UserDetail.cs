using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.UserModels
{
    public class UserDetail
    {
        public List<VehicleListItem> Vehicles { get; set; }
    }
}
