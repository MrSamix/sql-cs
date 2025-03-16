using _07_Self_Task_Airlines.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _05_FluentAPI
{
    public static class InitilizerDB
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(
                new Airplane() { Id = 1, Model = "Boeing 737", MaxPassengers = 150, Type = "Commercial", Country = "USA" },
                new Airplane() { Id = 2, Model = "Boeing 747", MaxPassengers = 300, Type = "Commercial", Country = "USA" },
                new Airplane() { Id = 3, Model = "Boeing 757", MaxPassengers = 200, Type = "Commercial", Country = "USA" },
                new Airplane() { Id = 4, Model = "Boeing 767", MaxPassengers = 250, Type = "Commercial", Country = "USA" },
                new Airplane() { Id = 5, Model = "Boeing 777", MaxPassengers = 350, Type = "Commercial", Country = "USA" },
                new Airplane() { Id = 6, Model = "Boeing 787", MaxPassengers = 400, Type = "Commercial", Country = "USA" }
                );
        }

        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            Account account1 = new Account() { Id = 1, Login = "ivan123", Password = "password1" };
            Account account2 = new Account() { Id = 2, Login = "maria123", Password = "password2" };
            Account account3 = new Account() { Id = 3, Login = "john123", Password = "password3" };
            Account account4 = new Account() { Id = 4, Login = "anna123", Password = "password4" };
            Account account5 = new Account() { Id = 5, Login = "peter123", Password = "password5" };


            modelBuilder.Entity<Account>().HasData(
                account1,
                account2,
                account3,
                account4,
                account5
            );
        }


        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            Client client1 = new Client() { Id = 1, Name = "Ivan", Email = "ivan@example.com", Sex = "Male", Surname = "Ivanov", AccountId = 1 };
            Client client2 = new Client() { Id = 2, Name = "Maria", Email = "maria@example.com", Sex = "Female", Surname = "Petrova", AccountId = 2 };
            Client client3 = new Client() { Id = 3, Name = "John", Email = "john@example.com", Sex = "Male", Surname = "Doe", AccountId = 3 };
            Client client4 = new Client() { Id = 4, Name = "Anna", Email = "anna@example.com", Sex = "Female", Surname = "Smith", AccountId = 4 };
            Client client5 = new Client() { Id = 5, Name = "Peter", Email = "peter@example.com", Sex = "Male", Surname = "Johnson", AccountId = 5 };


            modelBuilder.Entity<Client>().HasData(
                client1,
                client2,
                client3,
                client4,
                client5
            );
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            Client client1 = new Client() { Id = 1, Name = "Ivan", Email = "ivan@example.com", Sex = "Male", Surname = "Ivanov", Account = new Account() { Login = "ivan123", Password = "password1" } };
            Client client2 = new Client() { Id = 2, Name = "Maria", Email = "maria@example.com", Sex = "Female", Surname = "Petrova", Account = new Account() { Login = "maria123", Password = "password2" } };
            Client client3 = new Client() { Id = 3, Name = "John", Email = "john@example.com", Sex = "Male", Surname = "Doe", Account = new Account() { Login = "john123", Password = "password3" } };
            Client client4 = new Client() { Id = 4, Name = "Anna", Email = "anna@example.com", Sex = "Female", Surname = "Smith", Account = new Account() { Login = "anna123", Password = "password4" } };
            Client client5 = new Client() { Id = 5, Name = "Peter", Email = "peter@example.com", Sex = "Male", Surname = "Johnson", Account = new Account() { Login = "peter123", Password = "password5" } };



            modelBuilder.Entity<Flight>().HasData(
                new Flight() { Id = 1, LocationFrom = "Sofia", LocationTo = "London", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 1 },
                new Flight() { Id = 2, LocationFrom = "Sofia", LocationTo = "Paris", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 2 },
                new Flight() { Id = 3, LocationFrom = "Sofia", LocationTo = "Berlin", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 3     },
                new Flight() { Id = 4, LocationFrom = "Sofia", LocationTo = "Madrid", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 4 },
                new Flight() { Id = 5, LocationFrom = "Sofia", LocationTo = "Rome", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 5 },
                new Flight() { Id = 6, LocationFrom = "Sofia", LocationTo = "Vienna", DateFrom = new DateTime(2020, 12, 12), DateTo = new DateTime(2020, 12, 12), AirplaneId = 6 }
                );
        }

        public static void SeedClientFlight(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("ClientFlight").HasData(
                new { ClientsId = 1, FlightsId = 1 },
                new { ClientsId = 2, FlightsId = 2 },
                new { ClientsId = 3, FlightsId = 3 },
                new { ClientsId = 4, FlightsId = 4 },
                new { ClientsId = 5, FlightsId = 5 },
                new { ClientsId = 1, FlightsId = 6 }
            );
        }

    }
}
