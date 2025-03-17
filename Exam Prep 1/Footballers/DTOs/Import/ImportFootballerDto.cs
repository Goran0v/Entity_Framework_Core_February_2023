using Footballers.Data.Models.Uttilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DTOs.Import
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        public DateTime ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        public DateTime ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        public PositionType PositionType { get; set; }

        [XmlElement("BestSkillType")]
        public BestSkillType BestSkillType { get; set; }
    }
}
