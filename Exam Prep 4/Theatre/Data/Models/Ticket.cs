﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; } = null!;

        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }

        public virtual Theatre Theatre { get; set; } = null!;
    }
}
