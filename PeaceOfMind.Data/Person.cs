using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsCustomer { get; set; } // If person is not a customer, they are a lead

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

        // public CommunicationType PreferredCommunication { get; set; }
        // public ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();
        // public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    //public enum CommunicationType
    //{
    //    Call,
    //    Text,
    //    Email
    //}
}

