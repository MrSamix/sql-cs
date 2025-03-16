using _05_FluentAPI;
using _07_Self_Task_Airlines.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Self_Task_Airlines
{
    public class Airlines_Db : DbContext
    {
        public Airlines_Db()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        DbSet<Account> Accounts { get; set; }
        DbSet<Airplane> Airplanes { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AirlinesDB"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent api conf
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Account)
                .WithOne(a => a.Client)
                .HasForeignKey<Client>(c => c.AccountId);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(x => x.Flights);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithOne(x => x.Flight)
                .HasForeignKey<Flight>(f => f.AirplaneId);

            modelBuilder.SeedAccounts();
            modelBuilder.SeedClients();
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
            modelBuilder.SeedClientFlight();
        }
    }
}
