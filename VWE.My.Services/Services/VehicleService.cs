using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using VWE.My.Data;
using VWE.My.Services.ServiceModel;
using VWE.My.Data.Models;

namespace VWE.My.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            this.vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Gets all the vehicles
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<VehicleDTO>> GetAll(VehiclePagingParams pagingParams)
        {
            var vehicles = await vehicleRepository.GetAll(pagingParams);

            return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDTO>>(vehicles);
        }

        /// <summary>
        /// Gets a vehicle by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<VehicleDTO> GetById(int id)
        {
           var vehicle = await vehicleRepository.GetById(id);
           return mapper.Map(vehicle, new VehicleDTO());
        }

        /// <summary>
        /// Update a specific vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateVehicle"></param>
        /// <returns></returns>
        public async Task<VehicleDTO> UpdateVehicle(int id, UpdateVehicleDTO updateVehicle)
        {
            var vehicle = await vehicleRepository.GetById(id);
            if (vehicle == null) return null;

            DateTime dateVehicle = vehicle.ConstructionDate ?? DateTime.Now;
            vehicle.ConstructionDate = new DateTime(updateVehicle.ConstructionYear, dateVehicle.Month, dateVehicle.Day);
            vehicle.Color = updateVehicle.Color;
            await vehicleRepository.UpdateVehicle(vehicle);

            return mapper.Map(vehicle, new VehicleDTO());
        }

        /// <summary>
        /// Gets the vehicle by registration number
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <returns></returns>
        public async Task<VehicleDTO> GetByRegistrationNumber(string registrationNumber)
        {
           var vehicle = await  vehicleRepository.GetByRegistrationNumber(registrationNumber);
           return mapper.Map(vehicle, new VehicleDTO());
        }
    }
}
