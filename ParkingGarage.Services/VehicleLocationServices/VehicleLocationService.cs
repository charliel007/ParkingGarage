using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Data;
using ParkingGarage.Data.Entities;
using ParkingGarage.Models.VehicleLocationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.VehicleLocationServices
{
    public class VehicleLocationService : IVehicleLocationService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public VehicleLocationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateVehicleLocation(VehicleLocationCreate model)
        {
            var vehiclelocation = _mapper.Map<VehicleLocationEntity>(model);
            await _context.VehicleLocations.AddAsync(vehiclelocation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<VehicleLocationListItem>> GetAllVehicleLocations()
        {
            var conversion = await _context.VehicleLocations.ToListAsync();
            return _mapper.Map<List<VehicleLocationListItem>>(conversion);
        }
    }
}
