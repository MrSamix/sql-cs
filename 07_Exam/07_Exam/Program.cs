using DbInitilizer;
using Library;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        LibraryApp app = new LibraryApp();
        app.Login("admin", "admin");
        /*app.PrintAllBooks();
        app.PopularAuthorsByWeek();
        app.PopularGenresByMonth();*/
        app.Menu();
    }
}