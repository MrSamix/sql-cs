﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EF_CodeFirst.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }

        // Conn
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
    }
}
