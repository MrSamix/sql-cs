using DbInitilizer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DbInitilizer
{
    public class Db_Initilizer : DbContext
    {
        //public Db_Initilizer()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Sell> Sells { get; set; }


        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Book)
                .WithOne(b => b.Account)
                .HasForeignKey<Book>(b => b.AccountReservationId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Sale)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.SaleId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.SubBook)
                .WithOne(b => b.BookContinue)
                .HasForeignKey<Book>(b => b.SubBookId);
            //.OnDelete(DeleteBehavior.SetNull); // auto set null to another book, error
            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Account)
                .WithOne(a => a.Sell)
                .HasForeignKey<Sell>(s => s.AccountId);
            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Book)
                .WithOne(b => b.Sell)
                .HasForeignKey<Sell>(s => s.BookId);

            modelBuilder.InitAccounts();
            modelBuilder.InitSales();
            modelBuilder.InitBooks();
            modelBuilder.InitSells();
        }
    }
}
