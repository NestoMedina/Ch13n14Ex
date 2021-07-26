using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        //static private List<string> Events = new List<string>();


        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string desc)
        {
            Event newEvent = new Event(name, desc);
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

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
        public IActionResult SubmittedEditEventForm(int eventId, string name, string description)
        {
            EventData.SubmitEditEvent(eventId, name, description);
            return Redirect("/Events");
        }

        public IActionResult EventInfo()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
    }


}
