using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Service
    {
        // Services will only be editable by administrator
        
        public int ServiceId { get; set; }

        public string Name { get; set; }

        // Rate - should time be int? - I might need to do math with it, which doesn't make me want to use string. TimeSpan is another option but it's not really a time interval, more like a defined time amount
        public double Price { get; set; } // rate numerator

        public int Minutes { get; set; } // rate denominator, if above 60 convert to hours and minutes - somewhere else

        public int MinMinutes { get; set; } // in minutes, if above 60 convert to hours and minutes - somewhere else

        // Should this be in the data layer, or should it just be in html?
        public string Description { get; set; } // This is where you can add details like "includes 2 visits, feeding and watering, etc"

        // public ServiceType ServiceType { get; set; }

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();


    }

    //public enum ServiceType
    //{
    //    Dog,
    //    Cat,
    //    Horse,
    //    Other
    //}
}

