using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext _context;
        public EventCategoryController(EventDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<EventCategory> events = _context.Category.ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addModel = new AddEventCategoryViewModel();
            return View(addModel);
        }

        [HttpPost("/EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel newModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newInput = new EventCategory
                {
                    Name = newModel.Name
                };
                _context.Category.Add(newInput);
                _context.SaveChanges();
                return Redirect("/EventCategory/Index");
            }
            return View("/EventCategory/Create", newModel);
        }

        public IActionResult EventInfo()
        {
            List<EventCategory> events = _context.Category.ToList();
            ViewBag.events = events;
            return View();
        }
    }
}
