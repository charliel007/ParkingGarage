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

        public async Task<List<ReservationListItem>> GetAllReservations()
        {
            var conversion = await _context.Reservations
                .Include(r => r.LocationEntity)
                .ToListAsync(); //
            
            var mapped = _mapper.Map<List<ReservationListItem>>(conversion);
            return mapped;
        }

        public async Task<ReservationDetail> GetReservationById(int id)
        {
            var reservation = await _context.Reservations.Include(r => r.LocationEntity).FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null) return new ReservationDetail();

            return _mapper.Map<ReservationDetail>(reservation);
        }

        public async Task<IEnumerable<SelectListItem>> SelectLocationListItemConversion()
        {
            return await _context.Locations.Select(l => new SelectListItem
            {
                Text = l.Name,
                Value = l.Id.ToString()
            }).ToListAsync();
        }

    }
}
