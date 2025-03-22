﻿// <auto-generated />
using System;
using DbInitilizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbInitilizer.Migrations
{
    [DbContext(typeof(Db_Initilizer))]
    [Migration("20250321201738_ConfigReferences")]
    partial class ConfigReferences
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbInitilizer.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookSize")
                        .HasColumnType("int");

                    b.Property<string>("DistributorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("SalePrice")
                        .HasColumnType("int");

                    b.Property<int?>("SubBookId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountReservationId")
                        .IsUnique()
                        .HasFilter("[AccountReservationId] IS NOT NULL");

                    b.HasIndex("SaleId");

                    b.HasIndex("SubBookId")
                        .IsUnique()
                        .HasFilter("[SubBookId] IS NOT NULL");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Sell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Book", b =>
                {
                    b.HasOne("DbInitilizer.Entities.Account", "Account")
                        .WithOne("Book")
                        .HasForeignKey("DbInitilizer.Entities.Book", "AccountReservationId");

                    b.HasOne("DbInitilizer.Entities.Sale", "Sale")
                        .WithMany("Books")
                        .HasForeignKey("SaleId");

                    b.HasOne("DbInitilizer.Entities.Book", "SubBook")
                        .WithOne("BookContinue")
                        .HasForeignKey("DbInitilizer.Entities.Book", "SubBookId");

                    b.Navigation("Account");

                    b.Navigation("Sale");

                    b.Navigation("SubBook");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Sell", b =>
                {
                    b.HasOne("DbInitilizer.Entities.Account", "Account")
                        .WithOne("Sell")
                        .HasForeignKey("DbInitilizer.Entities.Sell", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbInitilizer.Entities.Book", "Book")
                        .WithOne("Sell")
                        .HasForeignKey("DbInitilizer.Entities.Sell", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DbInitilizer.Entities.Account", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();

                    b.Navigation("Sell")
                        .IsRequired();
                });

            modelBuilder.Entity("DbInitilizer.Entities.Book", b =>
                {
                    b.Navigation("BookContinue")
                        .IsRequired();

                    b.Navigation("Sell")
                        .IsRequired();
                });

            modelBuilder.Entity("DbInitilizer.Entities.Sale", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
