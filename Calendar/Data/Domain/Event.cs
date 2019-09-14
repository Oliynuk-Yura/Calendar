using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Data.Domain
{
    public class Event: Identifiable
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}
