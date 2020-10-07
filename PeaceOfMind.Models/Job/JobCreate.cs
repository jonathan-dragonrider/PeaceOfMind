using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Job
{
    public class JobCreate
    {
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Required]
        [Display(Name = "Pet(s)")]
        public List<int> PetIds { get; set; }

        // Simple way for user to choose a date and time?
        // Add StartDate and StartTime back together - this way there are two form fields for date and time, I feel like this would make it simpler for the user?

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        public string Note { get; set; }

    }
}
