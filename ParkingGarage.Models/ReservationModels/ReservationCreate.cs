using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingGarage.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Models.ReservationModels
{
    public class ReservationCreate
    {
        public string? IssuedNumber { get; set; }
        public ReservationType ReservationType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LocationEntityId { get; set; }
        public IEnumerable<SelectListItem> LocationOptions { get; set; } = new List<SelectListItem>();
        
    }
}
