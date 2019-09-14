using Calendar.Data.Domain;
using Calendar.Data.Repository.Abstract.Common;
using Calendar.Models.Calendar;
using System.Collections.Generic;

namespace Calendar.Bl.Repository.Abstract
{
    public interface ICalendarRepository : IGenericRepository<Event>
    {
        IEnumerable<MonthCalendarModel> GenarateCalendar(int year, int month);

    }
}
