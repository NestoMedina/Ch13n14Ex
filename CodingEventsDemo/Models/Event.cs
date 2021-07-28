using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Attendees { get; set; }
        public int Id { get; }
        private static int nextId = 1;

        public Event ()
        {
            this.Id = nextId;
            nextId++;
        }
        public Event(string name, string description, string location, int attendees) : this ()
        {
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Attendees = attendees;

        }
    }
}
