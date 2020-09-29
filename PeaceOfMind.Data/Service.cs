using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; } 

        public int Duration { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string Description { get; set; } 

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();


        // Additional ideas
        // public int MinimumDuration { get; set; }
        // public ServiceType ServiceType { get; set; }

    }

    public enum DurationUnit
    {
        Minutes,
        Hours
    }

    //public enum ServiceType
    //{
    //    Dog,
    //    Cat,
    //    Horse,
    //    Other
    //}
}

