using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.BoardgameNameMinLength)]
        [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Range(ValidationConstants.BoardgameRatingMinValue, ValidationConstants.BoardgameRatingMaxValue)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(ValidationConstants.BoardgameYearPublishedMinValue, ValidationConstants.BoardgameYearPublishedMaxValue)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.BoardgameCategoryTypeMinValue, ValidationConstants.BoardgameCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
