using AutoMapper;
using VWE.My.Services.ServiceModel;
using VWE.My.Data;

namespace VWE.My.Web.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<UpdateVehicleDTO, Vehicle>();
            CreateMap<Vehicle, UpdateVehicleDTO>();
            CreateMap<VehicleDTO, Vehicle>();
            CreateMap<Vehicle, VehicleDTO>();
        }
    }
}
