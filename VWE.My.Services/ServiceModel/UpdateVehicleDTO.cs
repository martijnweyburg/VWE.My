using System;
using System.ComponentModel.DataAnnotations;
using VWE.My.Services.ValidationAttributes;

namespace VWE.My.Services.ServiceModel
{
    public class UpdateVehicleDTO
    {
        [Required]
        public string Color { get; set; }

        [Required]
        [ValidateConstructionYear]
        public int ConstructionYear { get; set; }
    }
}
