using Calendar.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Data.Database
{
    public class CalendarContext : DbContext
    {
        public CalendarContext
            (DbContextOptions<CalendarContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Event { get; set; }
    }
}
