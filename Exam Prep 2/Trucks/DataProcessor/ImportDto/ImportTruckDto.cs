using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(ValidationConstants.RegistrationNumberLength)]
        [MaxLength(ValidationConstants.RegistrationNumberLength)]
        [RegularExpression(ValidationConstants.RegistrationNumberRegex)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [MinLength(ValidationConstants.VinNumberLength)]
        [MaxLength(ValidationConstants.VinNumberLength)]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(ValidationConstants.TankCapacityMinValue, ValidationConstants.TankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstants.CargoCapacityMinValue, ValidationConstants.CargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.CategoryTypeMinValue, ValidationConstants.CategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Range(ValidationConstants.MakeTypeMinValue, ValidationConstants.MakeTypeMaxValue)]
        public int MakeType { get; set; }
    }
}
