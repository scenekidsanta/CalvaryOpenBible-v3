using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [Display(Name = "Event Time")]
        public DateTime? EventTime { get; set; }
        public string EventDescription { get; set; }
        public EventViewModel Events { get; set; }


        public class EventViewModel
        {
            public string EventType { get; set; }
            public string EventName { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime StartDate { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime EndDate { get; set; }
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
            [Display(Name = "Event Time")]
            public DateTime? EventTime { get; set; }
            public string EventDescription { get; set; }

        }
    }
}