using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; } = null!;

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; } = null!;

        [XmlElement("Raiting")]
        [Range(ValidationConstants.PlayRatingMinValue, ValidationConstants.PlayRatingMaxValue)]
        public double Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; } = null!;

        [XmlElement("Description")]
        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.SreenwriterMinLength)]
        [MaxLength(ValidationConstants.SreenwriterMaxLength)]
        public string Screenwriter { get; set; } = null!;
    }
}
