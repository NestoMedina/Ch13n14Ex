using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _context;
        public EventsController(EventDbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: /<controller>/
        //static private List<string> Events = new List<string>();

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = _context.Events.ToList();

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addModel = new AddEventViewModel();
            return View(addModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel newEvent)
        {
            if (ModelState.IsValid)
            {
                Event newInputEvent = new Event
                { Name = newEvent.Name,
                    Description = newEvent.Description,
                    Location = newEvent.Location,
                    Attendees = newEvent.Attendees,
                    Type = newEvent.Type
                };


                _context.Events.Add(newInputEvent);
                _context.SaveChanges();
                return Redirect("/Events");
            }
                return View(newEvent);
        } 

        public IActionResult Edit()
        {
            List<Event> events = _context.Events.ToList();
            ViewBag.events = events;
            return View();
        }

        public IActionResult EditEvent(string uniqueId)
        {
            ViewBag.sameId = uniqueId;
            return View();
        }

        [HttpPost("/Events/EditEvent")]
        public IActionResult SubmittedEditEventForm(int eventId, string name, string description, string location, int attendees)
        {
           // EventData.SubmitEditEvent(eventId, name, description, location, attendees);
            List<Event> events = _context.Events.ToList();
            foreach (Event item in events)
            {
                if (eventId == item.Id)
                {
                    item.Name = name;
                    item.Description = description;
                    item.Location = location;
                    item.Attendees = attendees;
                }
            }
            _context.SaveChanges();

            return Redirect("/Events");
        }

        public IActionResult EventInfo()
        {
            List<Event> events = _context.Events.ToList();
            ViewBag.events = events;
            return View();
        }

        public IActionResult Delete()
        {
            ViewBag.events = _context.Events.ToList();
            return View();
        }
        
        [HttpPost("/Events/Delete")]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                Event theEvent = _context.Events.Find(eventId);
                _context.Events.Remove(theEvent);
            }
            _context.SaveChanges();
            return Redirect("/Events");
        }
    }


}
