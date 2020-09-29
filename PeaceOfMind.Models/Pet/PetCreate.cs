using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Pet
{
    public class PetCreate
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public PetType PetType { get; set; }
    }
}
