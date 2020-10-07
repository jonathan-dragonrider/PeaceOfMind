using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Job
{
    public class JobListItem
    {
        public int JobId { get; set; }

        public string Service { get; set; }

        [Display(Name = "Date")]
        public string StartDate { get; set; }

        [Display(Name = "Time")]
        public string StartTime { get; set; }

        // For calendar
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

}
