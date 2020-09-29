using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Service
{
    public class ServiceEdit
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public int Duration { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string Description { get; set; }

    }
}
