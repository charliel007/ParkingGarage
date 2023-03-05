using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Data;
using ParkingGarage.Data.Entities;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.VehicleServices
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public VehicleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateVehicle(VehicleCreate model)
        {
            var vehicle = _mapper.Map<VehicleEntity>(model);

            

            await _context.Vehicles.AddAsync(vehicle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;
            else
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<VehicleListItem>> GetAllVehicles()
        {
            var conversion = await _context.Vehicles.Include(v => v.UserEntity).ToListAsync();
            return _mapper.Map<List<VehicleListItem>>(conversion);
        }

        public async Task<VehicleDetail> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.Include(v => v.UserEntity).FirstOrDefaultAsync(x => x.Id == id);
            if (vehicle == null) return new VehicleDetail();

            return _mapper.Map<VehicleDetail>(vehicle);
        }

        public async Task<bool> UpdateVehicle(VehicleEdit model)
        {
            var vehicle = await _context.Vehicles.FindAsync(model.Id);
            if (vehicle == null) return false;
            else
            {
                _mapper.Map(model, vehicle);
                /*vehicle.Year = model.Year;
                vehicle.Color = model.Color;
                vehicle.Model = model.Model;
                vehicle.Make = model.Make;
                vehicle.LicensePlateState = model.LicensePlateState;
                vehicle.LicensePlateNumber = model.LicensePlateNumber;*/

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
