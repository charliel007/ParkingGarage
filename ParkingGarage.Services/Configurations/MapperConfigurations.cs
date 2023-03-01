using AutoMapper;
using ParkingGarage.Data.Entities;
using ParkingGarage.Models.LocationModels;
using ParkingGarage.Models.ReservationModels;
using ParkingGarage.Models.UserModels;
using ParkingGarage.Models.VehicleLocationModels;
using ParkingGarage.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Services.Configurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<UserEntity, UserListItem>().ReverseMap();
            CreateMap<UserEntity, UserDetail>().ReverseMap();

            CreateMap<LocationEntity, LocationListItem>().ReverseMap();
            CreateMap<LocationEntity, LocationEdit>().ReverseMap();
            CreateMap<LocationEntity, LocationDetail>().ReverseMap();

            CreateMap<VehicleEntity, VehicleCreate>().ReverseMap();
            CreateMap<VehicleEntity, VehicleListItem>().ReverseMap();
            CreateMap<VehicleEntity, VehicleDetail>().ReverseMap();
            CreateMap<VehicleEntity, VehicleEdit>().ReverseMap();

            CreateMap<VehicleLocationEntity, VehicleLocationCreate>().ReverseMap();
            CreateMap<VehicleLocationEntity, VehicleLocationListItem>().ReverseMap();
            CreateMap<VehicleLocationEntity, VehicleLocationDetail>().ReverseMap();

            CreateMap<ReservationEntity, ReservationCreate>().ReverseMap();
            CreateMap<ReservationEntity, ReservationListItem>().ReverseMap();
            CreateMap<ReservationEntity, ReservationDetail>().ReverseMap();
        }
    }
}
