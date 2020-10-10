using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Models
{
    [DataContract(Name = "CalendarEvent")]
    class CalendarEvent
    {
        [DataMember]
        private string title;
        [DataMember]
        private string description;
        [DataMember]
        private string start;
        [DataMember]
        private string end;
        [DataMember]
        private string allday;
        [DataMember]
        private string url;
        [DataMember]
        private string color;
        [DataMember]
        private string borderColor;
        [DataMember]
        private string textColor;


        public CalendarEvent()
        {
        }

        public CalendarEvent(string t, string d, string s, string e, string a, string u, string col = null, string bcol = null, string tcol = null)
        {
            title = t;
            description = d;
            start = s;
            end = e;
            allday = a;
            url = u;
            color = col;
            borderColor = bcol;
            textColor = tcol;
        }
    }
}
