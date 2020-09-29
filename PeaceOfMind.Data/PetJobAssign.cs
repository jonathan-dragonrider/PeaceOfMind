using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class PetJobAssign
    {
        public int PetJobAssignId { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public virtual Dog Dog { get; set; }

        [ForeignKey("Cat")]
        public int CatId { get; set; }
        public virtual Cat Cat { get; set; }

        [ForeignKey("Horse")]
        public int HorseId { get; set; }
        public virtual Horse Horse { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }


    }
}
