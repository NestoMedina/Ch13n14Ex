using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Attendees { get; set; }
        public EventType Type { get; set; }

        public Event ()
        {
        }
        public Event(string name, string description, string location, int attendees)
        {
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Attendees = attendees;

        }
    }
}
