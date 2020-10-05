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

        [Display(Name = "Time")]
        public DateTime StartTime { get; set; }
    }
}
