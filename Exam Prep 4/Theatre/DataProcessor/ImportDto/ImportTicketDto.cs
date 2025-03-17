using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketDto
    {
        [Range((double)ValidationConstants.TicketMinPrice, (double)ValidationConstants.TicketMaxPrice)]
        public decimal Price { get; set; }

        [Range(ValidationConstants.RowNumberMinValue, ValidationConstants.RowNumberMaxValue)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}
