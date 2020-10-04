using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Pet
{
    public class PetListItem
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }

        [Display(Name = "Type")]
        public PetType TypeOfPet { get; set; }
    }
}
