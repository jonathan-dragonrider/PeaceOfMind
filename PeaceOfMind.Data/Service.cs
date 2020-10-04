using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DurationUnit DurationUnit { get; set; }

        public string Description { get; set; } 

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    }

    public enum DurationUnit
    {
        Minutes,
        Hours
    }

}

