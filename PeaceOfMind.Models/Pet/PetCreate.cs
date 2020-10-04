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

        [Display(Name = "Type")]
        public PetType TypeOfPet { get; set; }

        [Display(Name = "Owner")]
        public int ClientId { get; set; }
    }
}
