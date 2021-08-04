using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModel
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage="Category name is required.")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
