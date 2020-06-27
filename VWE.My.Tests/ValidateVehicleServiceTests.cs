using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using VWE.My.Services;
using VWE.My.Services.ServiceModel;
using VWE.My.Services.ValidationAttributes;
using VWE.My.Services.Constants;
using VWE.My.Data;
using VWE.My.Web.Profiles;

namespace VWE.My.Tests
{
    public class ValidateVehicleServiceTests
    {
        private IMapper mapper;
        [SetUp]
        public void Setup()
        {
            //auto mapper configuration
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VehicleProfile());
            });

            this.mapper = mapperConfig.CreateMapper();
        }


        /// <summary>
        /// Tests the update of a vehicle
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestUpdateExistingVehicle()
        {
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var updateYear = DateTime.Now.Year;

            var updateVehicle = new UpdateVehicleDTO()
            {
                Color = "grey",
                ConstructionYear = updateYear
            };

            var vehicle = new Vehicle()
            {
                Id = 1,
                //a different date than the updated date.
                ConstructionDate = DateTime.Now.AddYears(-10),
                Color = "pink",
                Make = "Ford"
            };

            vehicleRepositoryMock.Setup(v => v.GetById(It.IsAny<int>())).Returns(Task.FromResult(vehicle));
            vehicleRepositoryMock.Setup(v => v.UpdateVehicle(vehicle)).Verifiable();
            IVehicleService service = new VehicleService(vehicleRepositoryMock.Object, mapper);

            var returnVehicle = await service.UpdateVehicle(1, updateVehicle);

            DateTime dateVehicle = returnVehicle.ConstructionDate ?? DateTime.MinValue;

            //check if updated properties are changed
            Assert.True(dateVehicle != DateTime.MinValue);
            Assert.True(dateVehicle.Year == updateYear);
            Assert.True(returnVehicle.Color == "grey");
            //check if other properties are still the same.
            Assert.True(returnVehicle.Make == "Ford");

        }

        /// <summary>
        /// Test what should happen when a vehicle is not found when trying to update
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestUpdateNonExistingVehicle()
        {
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var updateDate = DateTime.Now.Year;

            var updateVehicle = new UpdateVehicleDTO()
            {
                Color = "grey",
                ConstructionYear = updateDate
            };

            Vehicle vehicle = null;

            vehicleRepositoryMock.Setup(v => v.GetById(It.IsAny<int>())).Returns(Task.FromResult(vehicle));
            vehicleRepositoryMock.Setup(v => v.UpdateVehicle(vehicle)).Verifiable();
            IVehicleService service = new VehicleService(vehicleRepositoryMock.Object, mapper);

            var returnVehicle = await service.UpdateVehicle(1, updateVehicle);

            //if vehicle is not found by the repository, then the returned vehicle of the service update function should be null.
            Assert.True(vehicle == null);
        }
    }
}