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

        [Display(Name = "$")]
        public double Price { get; set; }

        public int Minutes { get; set; }

        [Display(Name = "Minimum Time (minutes)")]
        public int MinMinutes { get; set; }

        public string Description { get; set; }

    }
}
