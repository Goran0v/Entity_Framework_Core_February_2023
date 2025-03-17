using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DTOs.Import
{
    public class ImportTeamDto
    {
        public string Name { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public ImportJsonFootballerDto[] Footballers { get; set; } = null!;
    }
}
