using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Data;
using ParkingGarage.Models.LocationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public LocationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<LocationListItem>> GetAllLocations()
        {
            var conversion = await _context.Locations.ToListAsync();

            return _mapper.Map<List<LocationListItem>>(conversion);
        }
    }
}
