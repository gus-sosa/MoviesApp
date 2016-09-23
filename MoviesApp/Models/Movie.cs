﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Tile { get; set; }

        public string Director { get; set; }

        public DateTime DateRealeased { get; set; }
    }
}