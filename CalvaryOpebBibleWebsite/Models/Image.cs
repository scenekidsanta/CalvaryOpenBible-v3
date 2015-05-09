using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryOpebBibleWebsite.Models
{
    public partial class Image
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Details { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
    }
}