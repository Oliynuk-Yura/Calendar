using Calendar.Entity.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.Calendar
{
    public class CalendarResponseModel
    {
        public IEnumerable<MonthCalendarModel> Month { get; set; }
        public PrevNextMonthModel PrevNextMonth  { get; set; }
    }
}
