using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using VWE.My.Services.ServiceModel;
using VWE.My.Services.ValidationAttributes;
using VWE.My.Services.Constants;

namespace VWE.My.Tests
{
    public class ValidateConstructionDateTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary>
        /// test: invalid date if the year of the constructiondate is below the lowest valid year.
        /// </summary>
        [Test]
        public void TestLowestValidConstructionDate()
        {
            var updateVehicle = new UpdateVehicleDTO()
            {
                Color = "grey",
                ConstructionYear = VehicleConstants.LOWEST_VALID_CONSTRUCTION_YEAR -1
            };

            var validationContext = new ValidationContext(updateVehicle);
            var validationAttribute = new ValidateConstructionYearAttribute();
            var result = validationAttribute.GetValidationResult(updateVehicle, validationContext);
            Assert.IsNotNull(result);
            Assert.True(result.ErrorMessage == string.Format(VehicleConstants.ERROR_NO_VALID_CONSTRUCTIONYEAR, VehicleConstants.LOWEST_VALID_CONSTRUCTION_YEAR, DateTime.Now.Year));
        }

        /// <summary>
        /// test: invalid date if the year of the construction date >= current year 
        /// </summary>
        [Test]
        public void TestCurrentConstructionDate()
        {
            var updateVehicle = new UpdateVehicleDTO()
            {
                Color = "grey",
                ConstructionYear= DateTime.Now.Year
            };

            var validationContext = new ValidationContext(updateVehicle);
            var validationAttribute = new ValidateConstructionYearAttribute();
            var result = validationAttribute.GetValidationResult(updateVehicle, validationContext);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// test the validation of a valid construction date. If the date is between the valid boundaries.
        /// </summary>
        [Test]
        public void TestValidConstructionDate()
        {
            var updateVehicle = new UpdateVehicleDTO()
            {
                Color = "grey",
                ConstructionYear = DateTime.Now.AddYears(-1).Year
            };

            var validationContext = new ValidationContext(updateVehicle);
            var validationAttribute = new ValidateConstructionYearAttribute();
            var result = validationAttribute.GetValidationResult(updateVehicle, validationContext);
            Assert.IsNull(result);
        }
    }
}