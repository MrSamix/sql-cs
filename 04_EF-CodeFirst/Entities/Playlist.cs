using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EF_CodeFirst.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public int CategoryId { get; set; }

        // Conn
        public Category Category { get; set; }
    }
}
