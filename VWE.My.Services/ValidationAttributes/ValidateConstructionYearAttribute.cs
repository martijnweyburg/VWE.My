using System;
using System.ComponentModel.DataAnnotations;
using VWE.My.Services.ServiceModel;
using VWE.My.Services.Constants;

namespace VWE.My.Services.ValidationAttributes
{
    public class ValidateConstructionYearAttribute : ValidationAttribute
    {

        /// <summary>
        /// Validates the Construction Date: should be between the lowest valid date and the curent years
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var updateVehicle = (UpdateVehicleDTO)validationContext.ObjectInstance;

            if (updateVehicle.ConstructionYear < VehicleConstants.LOWEST_VALID_CONSTRUCTION_YEAR || updateVehicle.ConstructionYear >= DateTime.Now.Year)
            {
                return new ValidationResult(string.Format(VehicleConstants.ERROR_NO_VALID_CONSTRUCTIONYEAR, VehicleConstants.LOWEST_VALID_CONSTRUCTION_YEAR, DateTime.Now.Year));
            }

            return ValidationResult.Success;
        }
    }
}
