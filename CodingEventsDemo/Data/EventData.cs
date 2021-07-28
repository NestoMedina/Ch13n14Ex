using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;


namespace CodingEventsDemo.Data
{

    public class EventData
    {
        static private Dictionary<int, Event> _events = new Dictionary<int, Event>();

        public static void Add(Event newEvent)
        {
            _events.Add(newEvent.Id, newEvent);
        }

        public static IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }

        public static void SubmitEditEvent(int eventId, string name, string description, string location, int attendees)
        {
            foreach (KeyValuePair<int, Event> org in _events)
            {
                if (eventId == org.Key)
                {
                    org.Value.Name = name;
                    org.Value.Description = description;
                    org.Value.Location = location;
                    org.Value.Attendees = attendees;
                    break;
                }
            }
        }


    }
}
