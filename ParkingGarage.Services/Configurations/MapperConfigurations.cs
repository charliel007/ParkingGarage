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


            CreateMap<VehicleEntity, VehicleCreate>().ReverseMap();
            CreateMap<VehicleEntity, VehicleListItem>().ReverseMap();

            CreateMap<VehicleEntity, VehicleDetail>()
                .ForMember(dest => dest.VehicleLocations, act => act
                .MapFrom(src => src.VehicleLocations))
                .ReverseMap();
            CreateMap<VehicleEntity, VehicleEdit>().ReverseMap();


            CreateMap<VehicleLocationEntity, VehicleLocationCreate>().ReverseMap();

            CreateMap<VehicleLocationEntity, VehicleLocationListItem>()
                .ForMember(dest => dest.Location, act => act.MapFrom(src => src.LocationEntity))
                .ForMember(dest => dest.Vehicle, act => act.MapFrom(src => src.VehicleEntity))
                .ReverseMap();


            CreateMap<ReservationEntity, ReservationCreate>()
                .ForMember(dest => dest.LocationEntityId, act => act.MapFrom(src => src.VehicleLocationEntity.LocationEntityId))
                .ForMember(dest => dest.VehicleEntityId, act => act.MapFrom(src => src.VehicleLocationEntity.VehicleEntityId))
                .ReverseMap();

            CreateMap<ReservationEntity, ReservationListItem>()
                .ForMember(dest => dest.VehicleLocation, act => act
                .MapFrom(src => src.VehicleLocationEntity))
                .ReverseMap();
        }
    }
}
