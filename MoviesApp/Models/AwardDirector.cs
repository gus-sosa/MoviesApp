using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class AwardDirector
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public int DirectorId { get; set; }

        public int AwardId { get; set; }

        public virtual Director Director { get; set; }

        public virtual Award Award { get; set; }
    }
}