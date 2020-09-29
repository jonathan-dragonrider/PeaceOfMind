using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class Client
    {
        [Key]
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
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();


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

