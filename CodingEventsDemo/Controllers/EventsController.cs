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
        // GET: /<controller>/
        //static private List<string> Events = new List<string>();

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> newList = new List<Event>(EventData.GetAll());

            return View(newList);
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
                    Attendees = newEvent.Attendees
                };


                EventData.Add(newInputEvent);
                return Redirect("/Events");
            }
                return View(newEvent);
        } 

 /*       [HttpPost]
        public IActionResult NewEvent(string name, string desc)
        {
            Event newEvent = new Event(name, desc);
            EventData.Add(newEvent);

            return Redirect("/Events");
        } */

        public IActionResult Edit()
        {
            ViewBag.events = EventData.GetAll();
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
            EventData.SubmitEditEvent(eventId, name, description, location, attendees);
            return Redirect("/Events");
        }

        public IActionResult EventInfo()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
    }


}
