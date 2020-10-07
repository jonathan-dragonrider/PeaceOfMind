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

        public int ClientId { get; set; }

        public string Client { get; set; }

        public int ServiceId { get; set; }

        public string Service { get; set; }

        public List<int> PetIds { get; set; }

        [Display(Name = "Pet(s)")]
        public List<string> PetNames { get; set; }

        [Display(Name = "Date")]
        public string StartDate { get; set; }

        [Display(Name = "Time")]
        public string StartTime { get; set; }

        public string End { get; set; }

        public string Note { get; set; }

    }
}
