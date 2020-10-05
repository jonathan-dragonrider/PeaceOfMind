using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Job
{
    public class JobDetail
    {
        public int JobId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Pet(s)")]
        public List<int> PetIds { get; set; }

        [Display(Name = "Time")]
        public DateTime StartTime { get; set; }

        public string Note { get; set; }
    }
}
