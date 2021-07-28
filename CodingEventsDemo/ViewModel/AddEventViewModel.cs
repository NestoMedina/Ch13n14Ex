using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModel
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage="Event name is required.")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Event description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must add a location.")]
        public string Location { get; set; }

        [Required(ErrorMessage="Must add number of guests.")]
        [Range(0,100000, ErrorMessage ="Number of guests must be betweeen 0 - 100000")]
        public int Attendees { get; set; }
    }
}
