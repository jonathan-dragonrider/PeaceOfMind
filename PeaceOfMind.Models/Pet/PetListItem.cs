using PeaceOfMind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Pet
{
    public class PetListItem
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public PetType PetType { get; set; }
    }
}
