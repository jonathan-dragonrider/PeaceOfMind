using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public PetType TypeOfPet { get; set; }

        [ForeignKey("Owner")]
        public int? ClientId { get; set; }
        public virtual Client Owner { get; set; }

        public virtual ICollection<PetToJob> PetsToJobs { get; set; } = new List<PetToJob>();
    }

    public enum PetType
    {
        Dog,
        Cat,
        Horse
    }
}
