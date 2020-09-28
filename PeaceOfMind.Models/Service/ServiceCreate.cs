using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models
{
    // Somehow make this only an admin privelage - how to assign privelages?
    public class ServiceCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "$")]
        public double Price { get; set; }

        [Required]
        public int Minutes { get; set; }

        [Required]
        [Display(Name = "Minimum Time (minutes)")]
        public int MinMinutes { get; set; }

        public string Description { get; set; }

    }
}
