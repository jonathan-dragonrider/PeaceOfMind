using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public string Note { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public virtual ICollection<PetToJob> PetsToJobs { get; set; } = new List<PetToJob>();

    }
}
