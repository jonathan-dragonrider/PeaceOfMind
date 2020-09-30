using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Pet
{
    public class PetCreate
    {
        public string Name { get; set; }

        public PetType Type { get; set; }

        [Display(Name = "Owner")]
        public int OwnerId { get; set; }
    }
}
