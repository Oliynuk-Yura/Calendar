using Calendar.Bl.Repository.Abstract;
using Calendar.Data.Database;
using Calendar.Data.Domain;
using Calendar.Data.Repository.Implementation.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Bl.Repository.Implementation
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {

        public EventRepository
            (
            CalendarContext context
            ) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetEventsByDate(DateTime date)
        {
            var events = await Context.Event
                            .Where(s => s.Date.ToShortDateString() == date.ToShortDateString())
                            .OrderBy(s=>s.Date.TimeOfDay)
                            .ToListAsync();

            return events;                
        }

    }
}
