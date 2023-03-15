using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Data;
using ParkingGarage.Data.Entities;
using ParkingGarage.Models.LocationModels;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ReservationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateReservation(ReservationCreate model)
        {
            var reservation = _mapper.Map<ReservationEntity>(model);          
            await _context.Reservations.AddAsync(reservation);


            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ReservationListItem>> GetAllReservations(string id)
        {
            var conversion = await _context.Reservations
                .Include(i => i.VehicleLocationEntity)
                .ThenInclude(r => r.Reservations)
                .Include(i2 => i2.VehicleLocationEntity)
                .ThenInclude(l => l.LocationEntity)
                .Include(i3 => i3.VehicleLocationEntity)
                .ThenInclude(v => v.VehicleEntity)
                .Where(i => i.VehicleLocationEntity.VehicleEntity.UserEntityId == id).ToListAsync();

            var mapped = _mapper.Map<List<ReservationListItem>>(conversion);
            return mapped;
        }

        public async Task<List<ReservationListItem>> GetForCompare()
        {
            var conversion = await _context.Reservations
                .Include(i => i.VehicleLocationEntity)
                .ThenInclude(r => r.Reservations)
                .Include(i2 => i2.VehicleLocationEntity)
                .ThenInclude(l => l.LocationEntity)
                .Include(i3 => i3.VehicleLocationEntity)
                .ThenInclude(v => v.VehicleEntity)
                .ToListAsync();

            var mapped = _mapper.Map<List<ReservationListItem>>(conversion);
            return mapped;
        }

        public async Task<IEnumerable<SelectListItem>> SelectLocationListItemConversion()
        {
            return await _context.Locations.Select(l => new SelectListItem
            {
                Text = l.Name,
                Value = l.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectVehicleListItemConversion(string id)
        {
            return await _context.Vehicles.Where(v => v.UserEntityId == id).Select(l => new SelectListItem
            {
                Text = l.LicensePlateNumber,
                Value = l.Id.ToString()
            }).ToListAsync();
        }

    }
}
