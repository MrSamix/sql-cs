using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EF_CodeFirst.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public double Duration { get; set; }

        // Conn
        public Album Album { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
