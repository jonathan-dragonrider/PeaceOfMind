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

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

    }
}
