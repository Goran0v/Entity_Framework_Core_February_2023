using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [Required]
        [MinLength(ValidationConstants.TheatreNameMinLength)]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(ValidationConstants.NumberOfHallsMinValue, ValidationConstants.NumberOfHallsMaxValue)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(ValidationConstants.DirectorNameMinLength)]
        [MaxLength(ValidationConstants.DirectorNameMaxLength)]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; } = null!;
    }
}
