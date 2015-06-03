﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalvaryOpebBibleWebsite.Models
{
    public class Pastor
    {
        public int PastorID { get; set; }

        [Required]
        public string PastorName { get; set; }
        [Required]
        public string PastorImagePath { get; set; }
        [Required]
        public string Title { get; set; }
            [Required]
        public string Details { get; set; }

    }
}
