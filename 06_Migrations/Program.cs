using _06_Migrations;
using _06_Migrations.Entities;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    // Documentation
    #region Laze Loading
    // Завантаження зв'язаних об'єктів відбувається лише в момент доступу до них
    // Required:
    // 1 - property must be public
    // 2 - class must be not sealed
    // 3 - property must be virtual
    // 4 - context.Configuration.LazyLoadingEnabled = True (default);

    /*foreach (var w in context.Workers)
    {
        Console.WriteLine($"--------- Worker [{w.Number}] {w.Name}");
        Console.WriteLine($"Department :: {w.Department?.Name}"); // load department
        if(w.CountryId != null)
        {
            Console.WriteLine($"Country :: {w.Country?.Name}");
        }
        foreach (var pr in w.Projects) // loading projects
        {
            Console.WriteLine($"\t Project :: {pr.Name}");
        }
    }*/
    #endregion

    #region Eager Loading
    // Завантаження зв'язаних об'єктів відбувається відразу при виконанні основного запиту
    // застосовується оператор JOIN
    //context.Workers.Include(proprtyName)
    // proprtyName - ім'я навігаційної властивості для не відкладеного завантаження

    /*var workerQuery = context.Workers.Include(nameof(Worker.Department))
        .Include(nameof(Worker.Country))
        .Include(nameof(Worker.Projects));
    foreach (var w in workerQuery)
    {
        Console.WriteLine($"--------- Worker [{w.Number}] {w.Name}");
        Console.WriteLine($"Department :: {w.Department?.Name}"); // load department
        if (w.CountryId != null)
        {
            Console.WriteLine($"Country :: {w.Country?.Name}");
        }
        foreach (var pr in w.Projects) // loading projects
        {
            Console.WriteLine($"\t Project :: {pr.Name}");
        }
    }*/
    #endregion

    #region Explicit loading
    // Завантаження звязаних обєктів відбувається явним викликом методів
    //context.Entry(entity).Reference(propName).Load() // для завантаження одного обєкта
    //context.Entry(entity).Collection(CollectionName).Load() // для завантаження колекції обєктів

    /* Console.WriteLine("Enter worker Id");
     int workerId;
     while (!int.TryParse(Console.ReadLine(), out workerId))
     {
         Console.WriteLine("Incorrect value. Try Again!");
     }
     // Find by id
     Worker worker = context.Workers.Find(workerId);
     if (worker == null)
     {
         Console.WriteLine("Worker not found");
         return;
     }
     // Load Reference
     context.Entry(worker).Reference(nameof(Worker.Department)).Load();
     Console.WriteLine($"---- Worker [{worker.Number}] {worker.Name}");
     Console.WriteLine($"Department :: {worker.Department?.Name}"); // department reference

     // load Collection
     context.Entry(worker).Collection(nameof(Worker.Projects)).Load();
     foreach (var item in worker.Projects)
     {
         Console.WriteLine($"\t Project :: {item.Name}");
     }*/
    #endregion


    private static void Main(string[] args)
    {
        MusicApp_db db = new MusicApp_db();


        // Task 2.1

        var avg = (from ii in db.Tracks where ii.Album.Name == "The Wall" select ii.Listeners).ToArray().Average();

        var res = from i in db.Tracks
                  where i.Album.Name == "The Wall" && i.Listeners >= avg
                  select i;

        foreach (var item in res)
        {
            Console.WriteLine(item.Name);
        }


        // Task 2.2
        var idArtist = db.Artists.Where(a => a.Name == "Angus").Select(a => a.Id).FirstOrDefault();

        // Top 3 tracks
        var top3_tracks = db.Tracks.Include(t => t.Album)
            .Where(t => t.Album.ArtistId == idArtist)
            .OrderByDescending(t => t.Rating)
            .Take(3)
            .ToList();
        Console.WriteLine("Top 3 Tracks:");
        foreach (var item in top3_tracks)
        {
            Console.WriteLine(item.Name);
        }

        // Top 3 albums
        var top3_albums = db.Albums
            .Where(a => a.ArtistId == idArtist)
            .OrderByDescending(a => a.Rating)
            .Take(3)
            .ToList();

        Console.WriteLine("Top 3 Albums:");
        foreach (var album in top3_albums)
        {
            Console.WriteLine(album.Name);
        }


        // Task 2.3
        // Search for tracks by part of name or text
        Console.WriteLine("Enter part of the track name or text to search:");
        string searchTerm = Console.ReadLine();
        var searchResults = SearchTracks(db, searchTerm);

        Console.WriteLine("Search Results:");
        foreach (var track in searchResults)
        {
            Console.WriteLine($"{track.Name} - {track.Text}");
        }
    }

    private static List<Track> SearchTracks(MusicApp_db db, string searchTerm)
    {
        return db.Tracks
            .Where(t => t.Name.Contains(searchTerm) || t.Text.Contains(searchTerm))
            .ToList();
    }

}