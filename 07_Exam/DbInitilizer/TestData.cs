using DbInitilizer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInitilizer
{
    public static class TestData
    {
        public static void InitAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Login = "admin", Password = "admin" },
                new Account { Id = 2, Login = "user", Password = "user" },
                new Account { Id = 3, Login = "user2", Password = "user2" }
                );
        }
        public static void InitBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Book1",
                    Author = "Author1",
                    DistributorName = "Distributor1",
                    BookSize = 100,
                    Genre = "Genre1",
                    Year = 2021,
                    Price = 100,
                    SalePrice = 50,
                    IsAvailable = true,
                    InsertDate = new DateTime(2025, 03, 20),
                    SubBookId = null,
                    AccountReservationId = 1,
                    SaleId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Book2",
                    Author = "Author2",
                    DistributorName = "Distributor2",
                    BookSize = 200,
                    Genre = "Genre2",
                    Year = 2022,
                    Price = 200,
                    SalePrice = 100,
                    IsAvailable = false,
                    InsertDate = new DateTime(2025, 03, 21),
                    SubBookId = 1,
                    AccountReservationId = null,
                    SaleId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Book3",
                    Author = "Author3",
                    DistributorName = "Distributor3",
                    BookSize = 300,
                    Genre = "Genre3",
                    Year = 2023,
                    Price = 300,
                    SalePrice = 150,
                    IsAvailable = true,
                    InsertDate = new DateTime(2025, 03, 19),
                    SubBookId = 2,
                    AccountReservationId = 2,
                    SaleId = 3
                }
                );
        }
        public static void InitSales(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, StartDate = new DateTime(2025, 03, 21), EndDate = new DateTime(2025, 03, 28), Discount = 50, Name = "Week sales" },
                new Sale { Id = 2, StartDate = new DateTime(2025, 03, 22), EndDate = new DateTime(2025, 03, 23), Discount = 30, Name = "Holidays sales!" },
                new Sale { Id = 3, StartDate = new DateTime(2025, 03, 24), EndDate = new DateTime(2025, 03, 30), Discount = 70, Name = "School holidays!" }
                );
        }

        public static void InitSells(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sell>().HasData(
                new Sell { Id = 1, AccountId = 2, BookId = 2, SellDate = new DateTime(2025, 03, 21) }
                );
        }

    }
}
