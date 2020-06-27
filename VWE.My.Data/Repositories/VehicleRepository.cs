using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VWE.My.Data.Models;

namespace VWE.My.Data
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VWEDbContext context) : base(context)
        { }

        /// <summary>
        /// Gets all vehicles from the data source
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Vehicle>> GetAll(VehiclePagingParams pagingParams)
        {
            return await All().OrderBy(v => v.Id)
            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
            .Take(pagingParams.PageSize)
            .ToListAsync();
        }

        /// <summary>
        /// Gets a vehicle by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vehicle> GetById(int id)
        {
            return await base.Find(id);
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            await UpdateAsync(vehicle);
        }

        public async Task<Vehicle> GetByRegistrationNumber(string registrationNumber)
        {
            return await FindByAsync(x => x.RegistrationNumber == registrationNumber);
        }
    }
}
