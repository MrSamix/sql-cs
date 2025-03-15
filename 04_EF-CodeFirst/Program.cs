using _04_EF_CodeFirst;

internal class Program
{
    private static void Main(string[] args)
    {
        MusicApp_db db = new MusicApp_db();
        //db.PrintTracks();
        db.CreatePlaylist();
    }
}