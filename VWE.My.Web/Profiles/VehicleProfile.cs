using AutoMapper;
using VWE.My.Services.ServiceModel;
using VWE.My.Data;

namespace VWE.My.Web.Profiles
{
    /// <summary>
    /// profile that is used by automapper.
    /// </summary>
    public class VehicleProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleProfile()
        {
            CreateMap<VehicleDTO, Vehicle>();
            CreateMap<Vehicle, VehicleDTO>();
        }
    }
}
