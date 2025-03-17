using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data
{
    public class EventmiDbContext : DbContext
    {
        public EventmiDbContext()
        {

        }

        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; } = null!;
    }
}
