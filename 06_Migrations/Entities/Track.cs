using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Migrations.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public double Duration { get; set; }

        public double? Rating { get; set; }
        public int Listeners { get; set; } = 0;

        public string? Text { get; set; }

        // Conn
        public Album Album { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
