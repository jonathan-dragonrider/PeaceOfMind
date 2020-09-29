using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public double TotalCost
        {
            get
            {
                double totalCost = 0;
                foreach (var item in Jobs)
                {
                    totalCost += item.Service.Cost;
                }
                return totalCost;
            }
        }

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();



    }
}
