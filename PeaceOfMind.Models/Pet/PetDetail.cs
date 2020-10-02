using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Pet
{
    public class PetDetail
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
        public PetType PetType { get; set; }
    }
}
