using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models
{
    public class ServiceCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DurationUnit DurationUnit { get; set; }

        public string Description { get; set; }

    }
}
