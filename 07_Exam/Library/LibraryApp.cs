using DbInitilizer;
using DbInitilizer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    public class LibraryApp
    {
        private bool isLoggedIn = false;
        Db_Initilizer db;
        public LibraryApp()
        {
            db = new Db_Initilizer();
        }
        public void Menu()
        {
            bool flag = true;
            if (!isLoggedIn)
            {
                Console.WriteLine("Login:");
                string login = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                Console.Clear();
                Login(login, password);
            }
            if (!isLoggedIn)
            {
                return;
            }
            while (flag)
            {
                Console.WriteLine("Menu:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Print All Books");
                Console.WriteLine("[2] Add book");
                Console.WriteLine("[3] Remove book");
                Console.WriteLine("[4] Update book");
                Console.WriteLine("[5] Sell book");
                Console.WriteLine("[6] Reserve book");
                Console.WriteLine("[7] Cancel reservation");
                Console.WriteLine("[8] Not available book");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[9] Add book to sale");
                Console.WriteLine("[10] Remove book from sale");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[11] Add sale");
                Console.WriteLine("[12] Remove sale");
                Console.WriteLine("[13] Update sale");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[14] Search book");
                Console.WriteLine("[15] View new books");
                Console.WriteLine("[16] Popular books");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[17] Popular authors");
                Console.WriteLine("[18] Popular genres");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[0] Logout & exit");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Input your choice");
                Console.ResetColor();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        PrintAllBooks();
                        break;
                    case "2":
                        Console.WriteLine("Title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Distributor name:");
                        string distributorName = Console.ReadLine();
                        Console.WriteLine("Book size:");
                        int bookSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Genre:");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Year:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Price:");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sale price:");
                        int salePrice = int.Parse(Console.ReadLine());
                        DateTime insertDate = DateTime.Now;
                        Console.WriteLine("Sub book id(insert null if no have):");
                        string subBookStringId = Console.ReadLine();
                        int? subBookId = (subBookStringId == "null") ? null : int.Parse(subBookStringId);
                        Console.WriteLine("Account reservation id(insert null if no have):");
                        string accountReservationStringId = Console.ReadLine();
                        int? accountReservationId = (accountReservationStringId == "null") ? null : int.Parse(accountReservationStringId);
                        Console.WriteLine("Sale id(insert null if no have):");
                        string saleStringId = Console.ReadLine();
                        int? saleId = (saleStringId == "null") ? null : int.Parse(saleStringId);
                        Console.Clear();
                        AddBook(title, author, distributorName, bookSize, genre, year, price, salePrice, insertDate, subBookId, accountReservationId, saleId);
                        break;
                    case "3":
                        Console.WriteLine("Book id:");
                        int removeId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        RemoveBook(removeId);
                        break;
                    case "4":
                        Console.WriteLine("Book id:");
                        int updateId = int.Parse(Console.ReadLine());
                        Book book = db.Books.FirstOrDefault(b => b.Id == updateId);
                        if (book == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Book not found!");
                            Console.ResetColor();
                            break;
                        }
                        Console.WriteLine("Title:");
                        string updateTitle = Console.ReadLine();
                        Console.WriteLine("Author:");
                        string updateAuthor = Console.ReadLine();
                        Console.WriteLine("Distributor name:");
                        string updateDistributorName = Console.ReadLine();
                        Console.WriteLine("Book size:");
                        int updateBookSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Genre:");
                        string updateGenre = Console.ReadLine();
                        Console.WriteLine("Year:");
                        int updateYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Price:");
                        int updatePrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sale price:");
                        int updateSalePrice = int.Parse(Console.ReadLine());
                        DateTime updateInsertDate = DateTime.Now;
                        Console.WriteLine("Sub book id:");
                        int? updateSubBookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Account reservation id:");
                        int updateAccountReservationId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sale id:");
                        int updateSaleId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        UpdateBook(updateId, updateTitle, updateAuthor, updateDistributorName, updateBookSize, updateGenre, updateYear, updatePrice, updateSalePrice, updateInsertDate, updateSubBookId, updateAccountReservationId, updateSaleId);
                        break;
                    case "5":
                        Console.WriteLine("Book id:");
                        int sellBookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Account id:");
                        int sellAccountId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        SellBook(sellBookId, sellAccountId);
                        break;
                    case "6":
                        Console.WriteLine("Book id:");
                        int reserveBookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Account id:");
                        int reserveAccountId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        ReserveBook(reserveBookId, reserveAccountId);
                        break;
                    case "7":
                        Console.WriteLine("Book id:");
                        int cancelReservationBookId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        CancelReservation(cancelReservationBookId);
                        break;
                    case "8":
                        Console.WriteLine("Book id:");
                        int notAvailableBookId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        NotAvailableBook(notAvailableBookId);
                        break;
                    case "9":
                        Console.WriteLine("Book id:");
                        int addBookToSaleBookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sale id:");
                        int addBookToSaleSaleId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        AddBookToSale(addBookToSaleBookId, addBookToSaleSaleId);
                        break;
                    case "10":
                        Console.WriteLine("Book id:");
                        int removeBookFromSaleBookId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        RemoveBookFromSale(removeBookFromSaleBookId);
                        break;
                    case "11":
                        Console.WriteLine("Name:");
                        string addSaleName = Console.ReadLine();
                        Console.WriteLine("Discount:");
                        int addSaleDiscount = int.Parse(Console.ReadLine());
                        Console.WriteLine("StartDate: ");
                        DateTime addSaleStartDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("EndDate: ");
                        DateTime addSaleEndDate = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                        AddSale(addSaleName, addSaleDiscount, addSaleStartDate, addSaleEndDate);
                        break;
                    case "12":
                        Console.WriteLine("Sale id:");
                        int removeSaleId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        RemoveSale(removeSaleId);
                        break;
                    case "13":
                        Console.WriteLine("Sale id:");
                        int SaleId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name:");
                        string updateSaleName = Console.ReadLine();
                        Console.WriteLine("Discount:");
                        int updateSaleDiscount = int.Parse(Console.ReadLine());
                        Console.WriteLine("StartDate: ");
                        DateTime updateSaleStartDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("EndDate: ");
                        DateTime updateSaleEndDate = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                        UpdateSale(SaleId, updateSaleName, updateSaleDiscount, updateSaleStartDate, updateSaleEndDate);
                        break;
                    case "14":
                        Console.WriteLine("1. By name");
                        Console.WriteLine("2. By author");
                        Console.WriteLine("3. By genre");
                        string searchChoice = Console.ReadLine();
                        Console.Clear();
                        switch (searchChoice)
                        {
                            case "1":
                                Console.WriteLine("Title:");
                                string searchTitle = Console.ReadLine();
                                Console.Clear();
                                SearchBookByName(searchTitle);
                                break;
                            case "2":
                                Console.WriteLine("Author:");
                                string searchAuthor = Console.ReadLine();
                                Console.Clear();
                                SearchBookByAuthor(searchAuthor);
                                break;
                            case "3":
                                Console.WriteLine("Genre:");
                                string searchGenre = Console.ReadLine();
                                Console.Clear();
                                SearchBookByGenre(searchGenre);
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error, invalid input!");
                                Console.ResetColor();
                                break;
                        }
                        break;
                    case "15":
                        Console.Clear();
                        ViewNewBooks();
                        break;
                    case "16":
                        Console.WriteLine("1. By day");
                        Console.WriteLine("2. By week");
                        Console.WriteLine("3. By month");
                        Console.WriteLine("4. By year");
                        string popularBooksChoice = Console.ReadLine();
                        Console.Clear();
                        switch (popularBooksChoice)
                        {
                            case "1":
                                PopularBooksByDay();
                                break;
                            case "2":
                                PopularBooksByWeek();
                                break;
                            case "3":
                                PopularBooksByMonth();
                                break;
                            case "4":
                                PopularBooksByYear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error, invalid input!");
                                Console.ResetColor();
                                break;
                        }
                        break;
                    case "17":
                        Console.WriteLine("1. By day");
                        Console.WriteLine("2. By week");
                        Console.WriteLine("3. By month");
                        Console.WriteLine("4. By year");
                        string popularAuthorsChoice = Console.ReadLine();
                        Console.Clear();
                        switch (popularAuthorsChoice)
                        {
                            case "1":
                                PopularAuthorsByDay();
                                break;
                            case "2":
                                PopularAuthorsByWeek();
                                break;
                            case "3":
                                PopularAuthorsByMonth();
                                break;
                            case "4":
                                PopularAuthorsByYear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error, invalid input!");
                                Console.ResetColor();
                                break;
                        }
                        break;
                    case "18":
                        Console.WriteLine("1. By day");
                        Console.WriteLine("2. By week");
                        Console.WriteLine("3. By month");
                        Console.WriteLine("4. By year");
                        string popularGenresChoice = Console.ReadLine();
                        Console.Clear();
                        switch (popularGenresChoice)
                        {
                            case "1":
                                PopularGenresByDay();
                                break;
                            case "2":
                                PopularGenresByWeek();
                                break;
                            case "3":
                                PopularGenresByMonth();
                                break;
                            case "4":
                                PopularGenresByYear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error, invalid input!");
                                Console.ResetColor();
                                break;
                        }
                        break;
                    case "0":
                        Logout();
                        flag = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Invalid input!");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void ErrorNotLogged()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are not logged in.");
            Console.ResetColor();
        }
        public void PrintBook(int id)
        {
            if (isLoggedIn)
            {
                var bookQuery = db.Books.Include(nameof(Book.Account))
                .Include(nameof(Book.Sale))
                .Include(nameof(Book.SubBook))
                .Where(b => b.Id == id);
                foreach (var book in bookQuery)
                {
                    Console.WriteLine($"{book.Id,-7} {book.Title,-10} {book.Author,-10} {book.DistributorName,-10} {book.BookSize,-7} {book.Genre,-10} {book.Year,-5} {book.Price,-7} {book.SalePrice,-7} {book.InsertDate.ToShortDateString(),-12} {book.SubBook?.Title,-10} {book.Account?.Login,-10} {book.Sale?.Name,-20} {book.IsAvailable.ToString(),-5}");
                }
            }
        }

        public void PrintAllBooks()
        {
            if (isLoggedIn)
            {
                Console.WriteLine($"{"Id", -7}| {"Title", -10}| {"Author", -10}| {"DistributorName", -15}| {"BookSize", -7}| {"Genre", -10}| {"Year", -5}| {"Price", -7}| {"SalePrice", -10}| {"InsertDate", -12}| {"SubBookTitle", -10}| {"AccountLogin", -10}| {"SaleName", -20}| {"IsAvailable", -5}|");
                Console.WriteLine($"{new string('-', 170)}");
                Console.WriteLine();
                var bookQuery = db.Books.Include(nameof(Book.Account))
                .Include(nameof(Book.Sale))
                .Include(nameof(Book.SubBook));
                foreach (var book in bookQuery)
                {
                    Console.WriteLine($"{book.Id, -7} {book.Title, -10} {book.Author, -10} {book.DistributorName, -15} {book.BookSize, -7} {book.Genre, -10} {book.Year, -5} {book.Price, -7} {book.SalePrice, -10} {book.InsertDate.ToShortDateString(), -12} {book.SubBook?.Title ,-10} {book.Account?.Login,-10} {book.Sale?.Name,-20} {book.IsAvailable.ToString(),-5}");
                }
            }
            else
            {
                ErrorNotLogged();
            }

        }
        public void Login(string login, string password)
        {
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login && a.Password == password);
            if (db.Accounts.Contains(account))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logged succesfully");
                Console.ResetColor();
                isLoggedIn = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found! Not logged!");
                Console.ResetColor();
            }
        }
        public void Logout()
        {
            if (isLoggedIn)
            {

                isLoggedIn = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logged out");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void AddBook(string title, string author, string distributorName, int bookSize, string genre, int year, int price, int salePrice, DateTime insertDate, int? subBookId, int? accountReservationId, int? saleId)
        {
            if (isLoggedIn)
            {
                db.Books.Add(new Book()
                {
                    Title = title,
                    Author = author,
                    DistributorName = distributorName,
                    BookSize = bookSize,
                    Genre = genre,
                    Year = year,
                    Price = price,
                    SalePrice = salePrice,
                    InsertDate = insertDate,
                    SubBookId = subBookId,
                    AccountReservationId = accountReservationId,
                    SaleId = saleId
                });
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added!");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void RemoveBook(int id)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                    return;
                }
                db.Books.Remove(book);
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Removed!");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void UpdateBook(int id, string title, string author, string distributorName, int bookSize, string genre, int year, int price, int salePrice, DateTime insertDate, int? subBookId, int accountReservationId, int saleId)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                    return;
                }
                book.Title = title;
                book.Author = author;
                book.DistributorName = distributorName;
                book.BookSize = bookSize;
                book.Genre = genre;
                book.Year = year;
                book.Price = price;
                book.SalePrice = salePrice;
                book.InsertDate = insertDate;
                book.SubBookId = subBookId;
                book.AccountReservationId = accountReservationId;
                book.SaleId = saleId;
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Updated!");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }    
        }
        public void SellBook(int bookId, int accountId)
        {
            if (isLoggedIn)
            {
                db.Sells.Add(new Sell()
                {
                    BookId = bookId,
                    AccountId = accountId,
                    SellDate = DateTime.Now
                });
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sold!");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }    
        }
        public void ReserveBook(int bookId, int accountId)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
                else if (book.AccountReservationId != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book is already reserved!");
                    Console.ResetColor();
                }
                else if (book.IsAvailable == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book is not available!");
                    Console.ResetColor();
                }
                else
                {
                    book.AccountReservationId = accountId;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Reserved!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void CancelReservation(int bookId)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
                else if (book.AccountReservationId == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book is not reserved!");
                    Console.ResetColor();
                }
                else
                {
                    book.AccountReservationId = null;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Reservation canceled!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void NotAvailableBook(int bookId) // списати книгу
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
                else
                {
                    book.IsAvailable = false;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Set book is not available!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void AddBookToSale(int bookId, int saleId)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
                else if (book.SaleId != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book is already in sale!");
                    Console.ResetColor();
                }
                else
                {
                    book.SaleId = saleId;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book added to sale!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void RemoveBookFromSale(int bookId)
        {
            if (isLoggedIn)
            {
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.SaleId = null;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book removed from sale!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void AddSale(string name, int discount, DateTime startDate, DateTime endDate)
        {
            if (isLoggedIn)
            {
                db.Sales.Add(new Sale()
                {
                    Name = name,
                    Discount = discount,
                    StartDate = startDate,
                    EndDate = endDate
                });
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sale added!");
                Console.ResetColor();
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void RemoveSale(int id)
        {
            if (isLoggedIn)
            {
                Sale sale = db.Sales.FirstOrDefault(s => s.Id == id);
                if (sale != null)
                {
                    if (sale.Books != null)
                    {
                        foreach (var book in sale.Books)
                        {
                            book.SaleId = null;
                        }
                    }

                    db.Sales.Remove(sale);
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sale removed!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sale not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void UpdateSale(int id, string name, int discount, DateTime startDate, DateTime endDate)
        {
            if (isLoggedIn)
            {
                Sale sale = db.Sales.FirstOrDefault(s => s.Id == id);
                if (sale != null)
                {
                    sale.Name = name;
                    sale.Discount = discount;
                    sale.StartDate = startDate;
                    sale.EndDate = endDate;
                    db.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sale updated!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sale not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void SearchBookByName(string title)
        {
            if (isLoggedIn)
            {
                var books = db.Books.Where(b => b.Title == title).ToList();
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        PrintBook(book.Id);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void SearchBookByAuthor(string author)
        {
            if (isLoggedIn)
            {
                var books = db.Books.Where(b => b.Author == author).ToList();
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        PrintBook(book.Id);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void SearchBookByGenre(string genre)
        {
            if (isLoggedIn)
            {
                var books = db.Books.Where(b => b.Genre == genre).ToList();
                
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        PrintBook(book.Id);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void ViewNewBooks()
        {
            if (isLoggedIn)
            {
                var books = db.Books.Where(b => b.InsertDate >= DateTime.Now.AddDays(-7)).ToList(); // last 7 days
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        PrintBook(book.Id);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Books not found!");
                    Console.ResetColor();
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularBooksByDay()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate == DateTime.Today)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    PrintBook(book.Id);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularBooksByWeek()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddDays(-7))
                    .ToList();
                foreach (var book in booksQuery)
                {
                    PrintBook(book.Id);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularBooksByMonth()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddMonths(-1))
                    .ToList();
                foreach (var book in booksQuery)
                {
                    PrintBook(book.Id);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularBooksByYear()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddYears(-1))
                    .ToList();

                foreach (var book in booksQuery)
                {
                    PrintBook(book.Id);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularAuthorsByDay()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate == DateTime.Today)
                    .ToList()
                    .DistinctBy(b => b.Book.Author)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Author);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularAuthorsByWeek()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddDays(-7))
                    .ToList()
                    .DistinctBy(b => b.Book.Author)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Author);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularAuthorsByMonth()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddMonths(-1))
                    .ToList()
                    .DistinctBy(b => b.Book.Author)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Author);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularAuthorsByYear()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddYears(-1))
                    .ToList()
                    .DistinctBy(b => b.Book.Author)
                    .ToList();

                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Author);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularGenresByDay()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate == DateTime.Today)
                    .ToList()
                    .DistinctBy(b => b.Book.Genre)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Genre);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularGenresByWeek()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddDays(-7))
                    .ToList()
                    .DistinctBy(b => b.Book.Genre)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Genre);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularGenresByMonth()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddMonths(-1))
                    .ToList()
                    .DistinctBy(b => b.Book.Genre)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Genre);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
        public void PopularGenresByYear()
        {
            if (isLoggedIn)
            {
                var booksQuery = db.Sells.Include(nameof(Sell.Book))
                    .Where(s => s.SellDate >= DateTime.Now.AddYears(-1))
                    .ToList()
                    .DistinctBy(b => b.Book.Genre)
                    .ToList();
                foreach (var book in booksQuery)
                {
                    Console.WriteLine(book.Book.Genre);
                }
            }
            else
            {
                ErrorNotLogged();
            }
        }
    }
}
