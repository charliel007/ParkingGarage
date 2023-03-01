using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        public List<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

    }
}
