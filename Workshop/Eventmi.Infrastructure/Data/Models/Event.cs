using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Infrastructure.Data.Models
{
    [Comment("Събития")]
    public class Event
    {
        [Key]
        [Comment("Идентификатор на запис")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Име на събитието")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Начална дата и час")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Крайна дата и час")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Място на събитието")]
        public string Place { get; set; } = null!;
    }
}