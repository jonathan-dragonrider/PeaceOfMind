using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models.Job
{
    public class JobEdit
    {
        public int JobId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public string Note { get; set; }

    }
}
