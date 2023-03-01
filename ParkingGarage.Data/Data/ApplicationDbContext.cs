using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Entities;

namespace ParkingGarage.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<VehicleLocationEntity> VehicleLocations { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LocationEntity>().HasData(
                new LocationEntity
                {
                    Id = 1,
                    Name = "Parking Garage Noblesville",
                    Address = "1234 Noblesville Dr",
                    City = "Noblesville",
                    Spot = 10
                },
                new LocationEntity
                {
                    Id = 2,
                    Name = "Parking Garage Fishers",
                    Address = "1234 Fishers St",
                    City = "Fishers",
                    Spot = 10
                },
                new LocationEntity
                {
                    Id = 3,
                    Name = "Parking Garage Lawrence",
                    Address = "1234 Lawrence Ave",
                    City = "Indianapolis",
                    Spot = 10
                }
                );
        }
    } 
}