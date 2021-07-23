﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; }
        private static int nextId = 1;

        public Event(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Id = nextId;
            nextId++;
        }
    }
}