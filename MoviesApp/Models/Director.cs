using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Director
    {
        public int DirectorID { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Biography { get; set; }

        public virtual IEnumerable<Movie> Movies { get; set; }

        public virtual IEnumerable<AwardDirector> Awards { get; set; }
    }
}