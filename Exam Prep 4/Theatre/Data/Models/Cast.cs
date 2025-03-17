using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; } = null!;
    }
}
