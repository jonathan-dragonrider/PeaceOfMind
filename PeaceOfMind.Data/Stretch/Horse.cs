using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Horse
    {
        [Key]
        public int HorseId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Owner")]
        public int ClientId { get; set; }
        public virtual Client Owner { get; set; }

        public virtual ICollection<PetJobAssign> PetJobAssigns { get; set; } = new List<PetJobAssign>();

    }
}
