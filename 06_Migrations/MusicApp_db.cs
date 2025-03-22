using _06_Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Migrations
{
    public class MusicApp_db : DbContext
    {
        public MusicApp_db()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MusicAppDB"].ConnectionString);
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }


        public void PrintTracks()
        {
            foreach (var track in Tracks)
            {
                Console.WriteLine($"{track.Id} - {track.Name} - {track.Duration}");
            }
        }

        public void PrintCategories()
        {
            foreach (var category in Categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name}");
            }
        }

        public void CreatePlaylist()
        {
            Console.WriteLine("Enter the name of the playlist:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the id category of the playlist: ");
            PrintCategories();
            int categoryid = int.Parse(Console.ReadLine());
            Category category = Categories.FirstOrDefault(c => c.Id == categoryid);
            Console.Clear();
            PrintTracks();
            List<Track> tracks = new List<Track>();
            while (true)
            {
                Console.WriteLine("Enter the id of the track you want to add to the playlist(insert 0 if you finish add tracks): ");
                int trackId = int.Parse(Console.ReadLine());
                if (trackId == 0)
                {
                    break;
                }
                tracks.Add(Tracks.FirstOrDefault(t => t.Id == trackId));
            }
            Playlist playlist = new Playlist()
            {
                Name = name,
                Category = category,
                Tracks = tracks
            };

            Playlists.Add(playlist);
            SaveChanges();
            Console.WriteLine("Playlist added!");

        }
    }
}
