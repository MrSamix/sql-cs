using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ADO.NET_connection_mode
{
    public class Library
    {
        SqlConnection connection;
        public Library()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
            connection.Open();
            Console.WriteLine("Connected to database");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("[1] Add new book");
                Console.WriteLine("[2] Print count of registered users");
                Console.WriteLine("[3] Print all debtor clients");
                Console.WriteLine("[4] Print authors by book");
                Console.WriteLine("[5] Print all available books");
                Console.WriteLine("[6] Print all books by client");
                Console.WriteLine("[7] Clean all debtor");
                Console.WriteLine("[0] Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        string author = Console.ReadLine();
                        AddNewBook(title, author);
                        break;
                    case "2":
                        PrintCountOfClients();
                        break;
                    case "3":
                        PrintAllDebtorClients();
                        break;
                    case "4":
                        Console.Write("Enter book title: ");
                        string bookTitle = Console.ReadLine();
                        PrintAuthorsByBook(bookTitle);
                        break;
                    case "5":
                        PrintAllAvailableBooks();
                        break;
                    case "6":
                        Console.Write("Enter client name: ");
                        string clientName = Console.ReadLine();
                        PrintAllBooksByClient(clientName);
                        break;
                    case "7":
                        CleanAllDebtors();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void AddNewBook(string title, string author)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title) VALUES (@Title)", connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Authors (FullName) VALUES (@Author)", connection);
            cmd2.Parameters.AddWithValue("@Author", author);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("SELECT Id FROM Books WHERE Title = @Title", connection);
            cmd3.Parameters.AddWithValue("@Title", title);
            int bookId = (int)cmd3.ExecuteScalar();

            SqlCommand cmd4 = new SqlCommand("SELECT Id FROM Authors WHERE FullName = @Author", connection);
            cmd4.Parameters.AddWithValue("@Author", author);
            int authorId = (int)cmd4.ExecuteScalar();

            SqlCommand cmd5 = new SqlCommand("INSERT INTO BooksAuthors (BookId, AuthorId) VALUES (@BookId, @AuthorId)", connection);
            cmd5.Parameters.AddWithValue("@BookId", bookId);
            cmd5.Parameters.AddWithValue("@AuthorId", authorId);
            cmd5.ExecuteNonQuery();

            Console.Clear();
            Console.WriteLine("New book added.");
        }

        public void PrintCountOfClients()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(Id) FROM Clients", connection);
            int count = (int)cmd.ExecuteScalar();
            Console.Clear();
            Console.WriteLine($"Count of registered users: {count}");
        }

        public void PrintAllDebtorClients()
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT FullName FROM Clients where IsDebtor = 1", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Debtor: {reader[0]}");
            }
            reader.Close();
        }

        public void PrintAuthorsByBook(string bookTitle)
        {
            SqlCommand cmd = new SqlCommand("select a.FullName from Books as b join BooksAuthors as ba on ba.BookId = b.Id join Authors as a on ba.AuthorId = a.Id where b.Title = @Title", connection);
            cmd.Parameters.AddWithValue("@Title", bookTitle);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Author: {reader[0]}");
            }
            reader.Close();
        }

        public void PrintAllAvailableBooks()
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("select Title from Books where Id NOT IN (select BookId from ClientsBooks)", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Book: {reader[0]}");
            }
            reader.Close();
        }

        public void PrintAllBooksByClient(string clientName)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("select Title from Books where Id IN (select BookId from ClientsBooks join Clients on ClientsBooks.ClientId = Clients.Id where Clients.FullName = @Name)", connection);
            cmd.Parameters.AddWithValue("@Name", clientName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Book: {reader[0]}");
            }
            reader.Close();
        }

        public void CleanAllDebtors()
        {
            SqlCommand cmd = new SqlCommand("delete from ClientsBooks; update Clients set IsDebtor = 0 where IsDebtor = 1", connection);
            cmd.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("All debtors cleared.");
        }
    }
}
