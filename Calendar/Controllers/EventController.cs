using System;
using System.Threading.Tasks;
using Calendar.Bl.Repository.Abstract;
using Calendar.Data.Domain;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventController
            (
               IEventRepository eventRepository
            )
        {
            _eventRepository = eventRepository;
        }

        [Route("event/{date}")]
        public async Task<IActionResult> Index(string date)
        {
            DateTime currDate;
            if (string.IsNullOrEmpty(date))
            {
                return BadRequest();
            }

            var model = new EventModel();
            model.Time = DateTime.Now.TimeOfDay;

            if (DateTime.TryParse(date,out currDate))
            {              
                model.Events = 
                    await _eventRepository.GetEventsByDate(currDate);
                model.Date = currDate;
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventModel model)
        {
           DateTime dateEvent = model.Date.Add(model.Time);

           await _eventRepository.AddAsync(
               new Event()
               {
                    Date = dateEvent,
                    Title = model.Title
               });

            return RedirectToAction("Index", new { date = model.Date.ToShortDateString() });
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            var item = await _eventRepository.DeleteAsync(id);

            if (item is null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", new { date = item.Date.ToShortDateString() });
        }
    }
}