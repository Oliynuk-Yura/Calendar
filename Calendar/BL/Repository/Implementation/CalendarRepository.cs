using Calendar.Bl.Repository.Abstract;
using Calendar.Data.Database;
using Calendar.Data.Domain;
using Calendar.Data.Repository.Implementation.Common;
using Calendar.Entity.Calendar;
using Calendar.Models;
using Calendar.Models.Calendar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Bl.Repository.Implementation
{
    public class CalendarRepository : GenericRepository<Event>, ICalendarRepository
    {
        private const int dayInWeekCount = 7;
        private const int firstNumberOfMonth = 1;
        private const int countDisplayDay = 42;

        public CalendarRepository(CalendarContext context) : base(context)
        {
        }

        private IEnumerable<CalendarModel> GenarateCalendarArray(int year, int month)
        {  
            int [,] calendar = new int[6,7];
            List<CalendarModel> days = new List<CalendarModel>();
            //get number day of week first number this month
            DateTime currentDate = 
                new DateTime(year, month, firstNumberOfMonth);

            int numberLastDayOfCurrMonth = DateTime.DaysInMonth(year, month);

            int dayOfWeekFirstDate = (int)currentDate.DayOfWeek;
            int countDayOfWeekPrevMonth = dayOfWeekFirstDate == 0? dayInWeekCount-1 : dayOfWeekFirstDate-1;
            int numberLastDayOfPrevMonth = 0;

            PrevNextMonthModel prevNextMonth = new PrevNextMonthModel()
            {
                Date = currentDate
            };

            if (dayOfWeekFirstDate != (int)DayOfWeek.Monday)
            {
                numberLastDayOfPrevMonth = DateTime.DaysInMonth(prevNextMonth.PrevYear, prevNextMonth.PrevMonth);                
            }

            if (numberLastDayOfPrevMonth > 0)
            {
                int countDayPrevMonth = numberLastDayOfPrevMonth - countDayOfWeekPrevMonth + 1;
                //get a few day prev month

                for (int i = countDayPrevMonth; i <= numberLastDayOfPrevMonth; i++)
                {
                    days.Add(new CalendarModel()
                    {
                        Date = new DateTime(prevNextMonth.PrevYear, 
                                            prevNextMonth.PrevMonth, i),
                        IsCurrentMonth = false,
                    });
                }
            }

            //current month
            for (int i = firstNumberOfMonth; i <= numberLastDayOfCurrMonth; i++)
            {
                days.Add(new CalendarModel()
                {
                    Date = new DateTime(year, month, i),
                    IsCurrentMonth = true,
                });
            }

            int countDayNextMonth = countDisplayDay - (numberLastDayOfCurrMonth + countDayOfWeekPrevMonth);

            //get a few day  next month
            for (int i = firstNumberOfMonth; i <= countDayNextMonth; i++)
            {
                days.Add(new CalendarModel()
                {
                    Date = new DateTime(prevNextMonth.NextYear,
                                            prevNextMonth.NextMonth, i),
                    IsCurrentMonth = false,
                });
            }

            return days;
        }

        public IEnumerable<MonthCalendarModel> GenarateCalendar(int year, int month)
        {            

            var events = Context.Event.GroupBy(s => s.Date.ToShortDateString()).
                              Select(s => new EventDto
                              {
                                  Date = s.Select(t => t.Date).First(),
                                  Count = s.Count()
                              });

            List<CalendarModel> calendar = GenarateCalendarArray(year, month).ToList();

            var result = from c in calendar
                         join e in events on c.Date.ToShortDateString() equals e.Date.ToShortDateString() into g
                         from groups in g.DefaultIfEmpty()
                         select new MonthCalendarModel
                         {
                             Date = c.Date,
                             IsCurrentMonth = c.IsCurrentMonth,
                             Count = groups?.Count ?? 0
                         };

            return result.ToList();

        }

    }
}


                
