using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Client
    {
        public int ClientId { get; set; }

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

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();


        // Additional ideas
        // public CommunicationType PreferredCommunication { get; set; }
        
    }

    //public enum CommunicationType
    //{
    //    Call,
    //    Text,
    //    Email
    //}
}

