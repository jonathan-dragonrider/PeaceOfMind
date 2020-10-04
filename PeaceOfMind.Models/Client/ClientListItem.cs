using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Client
{
    public class ClientListItem
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
