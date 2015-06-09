using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalvaryOpebBibleWebsite.Models
{
    public class Ministries
    {
        [Key]
        [Required]
        public int MinitriesID { get; set; }

        [Required]
        public string MinistriesLeader { get; set; }
            [Required]
        public string MinistriesPosition { get; set; }
            [Required]
        public string MinistriesType { get; set; }

        public string MinistriesDescription { get; set; }

        public string LeaderImage { get; set; }

        public string LogoPath { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}