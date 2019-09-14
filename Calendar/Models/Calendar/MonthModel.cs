using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.Calendar
{
    public class MonthCalendarModel
    {
        public DateTime Date { get; set; }
        public bool IsCurrentMonth { get; set; }
        public int Count { get; set; }
    }
}
