using System.Collections.Generic;
using System.Threading.Tasks;
using VWE.My.Data;
using VWE.My.Services.ServiceModel;
using VWE.My.Data.Models;

namespace VWE.My.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDTO>> GetAll(VehiclePagingParams pagingParams);
        Task<VehicleDTO> GetById(int id);
        Task<VehicleDTO> UpdateVehicle(int id, UpdateVehicleDTO updateVehicle);
        Task<VehicleDTO> GetByRegistrationNumber(string registrationNumber);
    }
}
