using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime
        {
            get
            {
                switch (Service.DurationUnit)
                {
                    case DurationUnit.Minutes:

                        TimeSpan timeSpanMinutes = new TimeSpan(0, Service.Duration, 0);
                        return StartTime + timeSpanMinutes;

                    case DurationUnit.Hours:

                        TimeSpan timeSpanHours = new TimeSpan(Service.Duration, 0, 0);
                        return StartTime + timeSpanHours;

                    default:
                        return null;
                }
            }
        }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }


        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public string Note { get; set; }


        //[ForeignKey("Invoice")]
        //public int InvoiceId { get; set; }
        //public virtual Invoice Invoice { get; set; }
    }
}
