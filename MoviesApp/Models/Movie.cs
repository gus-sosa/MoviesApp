using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Tile { get; set; }

        public int DirectorId { get; set; }

        public DateTime DateRealeased { get; set; }

        public string Description { get; set; }

        public virtual Director Director { get; set; }
    }
}