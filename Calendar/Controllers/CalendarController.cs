using System;
using Calendar.Bl.Repository.Abstract;
using Calendar.Entity.Calendar;
using Calendar.Models.Calendar;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarController
            (
              ICalendarRepository calendarRepository
            )
        {
           _calendarRepository = calendarRepository;
        }

        [Route("{year}/{month}")]
        public IActionResult Index(int year, int month)
        {           
            var calendar =  _calendarRepository
                            .GenarateCalendar(year, month);

            var model = new CalendarResponseModel();
            model.Month = calendar;
            model.PrevNextMonth = new PrevNextMonthModel()
            {
                Date = new DateTime(year, month, 1)
            };

            return View(model);
        }
    }
}