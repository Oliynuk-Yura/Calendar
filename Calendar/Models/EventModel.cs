using Calendar.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class EventModel
    {
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
