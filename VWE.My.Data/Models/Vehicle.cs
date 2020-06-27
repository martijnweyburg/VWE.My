using System;

namespace VWE.My.Data
{
    public partial class Vehicle    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelVersion { get; set; }
        public string Color { get; set; }
        public int? Weight { get; set; }
        public string RegistrationNumber { get; set; }
        public int? NumberOfDoors { get; set; }
        public DateTime? ConstructionDate { get; set; }
        public string BodyType { get; set; }
        public string GearBox { get; set; }
    }
}
