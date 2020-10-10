using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web;

namespace PeaceOfMind.Models
{
    public class calendarjson : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
        }

        #endregion

        private List<CalendarEvent> _cal = new List<CalendarEvent>();

        public void ProcessRequest(HttpContext context)
        {
            //Here is where you populate List _cal with your source events

            //Instead, I'll load fake data for Events 1
            if (context.Request.QueryString["e1"] != "false")
            {
                for (int x = 1; x < 10; x++)
                {

                    int addDay = x % 2 == 0 ? x : x + 1;
                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay);
                    DateTime endDate = x % 4 == 0 ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay + 2) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay);
                    _cal.Add(new CalendarEvent(String.Format("Event1 {0}", x), "This is just a test event for source 1. Nothing to see really.", startDate.ToString("yyyy-MM-dd HH:mm"), endDate.ToString("yyyy-MM-dd HH:mm"), "false", "http://mikesmithdev.com", "#9fc6e7", "#1587bd", "#000000"));
                }
            }

            //And then I'll load fake data for Events 2
            if (context.Request.QueryString["e2"] != "false")
            {
                for (int x = 7; x< 23; x += 2)
                {

                    int addDay = x % 3 == 0 ? x : x + 2;
                    _cal.Add(new CalendarEvent(String.Format("Event2 {0}", x), "This is just a test event. Nothing to see really.", DateTime.Now.AddDays(addDay).ToString("yyyy-MM-dd HH:mm"), null, "false", "http://mikesmithdev.com", "#7c6995", "#5b447a", "#ffffff"));
                }
            }

            //This is the important part!
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(List<CalendarEvent>));
            s.WriteObject(stream, _cal);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            context.Response.ContentType = "application/json";
            context.Response.Write(sr.ReadToEnd());
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
