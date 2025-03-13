using _02_ADO.NET_connection_mode;

internal class Program
{
    private static void Main(string[] args)
    {
        Library db = new Library();

        db.Menu();
    }
}