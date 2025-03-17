using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Theatre.Common;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [MinLength(ValidationConstants.FullNameMinLength)]
        [MaxLength(ValidationConstants.FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}