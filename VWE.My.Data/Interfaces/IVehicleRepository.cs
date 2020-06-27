using System.Collections.Generic;
using System.Threading.Tasks;
using VWE.My.Data.Models;

namespace VWE.My.Data
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAll(VehiclePagingParams pagingParams);
        Task<Vehicle> GetById(int id);
        Task UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> GetByRegistrationNumber(string registrationNumber);
    }
}
