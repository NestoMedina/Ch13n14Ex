using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
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
    }
}
