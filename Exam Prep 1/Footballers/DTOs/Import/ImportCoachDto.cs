﻿using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DTOs.Import
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportFootballerDto[] Footballers { get; set; } = null!;
    }
}
