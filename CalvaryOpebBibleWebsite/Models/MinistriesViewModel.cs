using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryOpebBibleWebsite.Models
{
    public class MinistriesViewModel
    {
        public int MinitriesID { get; set; }
        public string MinistriesLeader { get; set; }
        public string MinistriesPosition { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventDescription { get; set; }
        public EventViewModel Events { get; set; }


        public class EventViewModel
        {
            public string EventType { get; set; }
            public string EventName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string EventDescription { get; set; }

        }
    }
}