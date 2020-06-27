using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VWE.My.Data;
using VWE.My.Services;
using VWE.My.Services.ServiceModel;
using VWE.My.Data.Models;

namespace VWE.My.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> logger;
        private readonly IVehicleService vehicleService;

        public VehiclesController(ILogger<VehiclesController> logger, IVehicleService vehicleService)
        {
            this.logger = logger;
            this.vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        }


        /// <summary>
        /// Gets a vehicle by registration number
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <returns></returns>
        [HttpGet("{registrationNumber}")]
        public async Task<ActionResult<VehicleDTO>> GetByRegistrationNumber(string registrationNumber)
        {
            try
            {
                var vehicle = await vehicleService.GetByRegistrationNumber(registrationNumber);

                if (vehicle == null) return NotFound("vehicle doesn't exist");

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to load vehicle by registration number. {ex.Message}");
            }
        }

        /// <summary>
        /// Get all vehicles from the database.
        /// This REST call uses paging with a maximum of 10 records a page.
        /// </summary>
        /// <param name="pagingParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetAll([FromQuery] VehiclePagingParams pagingParams)
        {
            try
            {
                var vehicles = await vehicleService.GetAll(pagingParams);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to load vehicle by id. {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the color and the Construction date of a vehicle. 
        /// The vehicle is found by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateVehicle"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VehicleDTO>> Update(int id, UpdateVehicleDTO updateVehicle)
        {
            if (updateVehicle == null)
            {
                return BadRequest($"{nameof(updateVehicle)} is empty");
            }
            try
            {

                var vehicle = await vehicleService.UpdateVehicle(id, updateVehicle);
                if (vehicle == null)
                {
                    return NotFound("vehicle not found");
                }
                else
                {
                    return vehicle;
                }
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update vehicle. {ex.Message}");
            }

        }
    }
}
