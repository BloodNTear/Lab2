﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230629085613_seedmorebook")]
    partial class seedmorebook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            Password = "admin",
                            Role = 1
                        },
                        new
                        {
                            Username = "staff",
                            Password = "staff",
                            Role = 2
                        });
                });

            modelBuilder.Entity("Repository.Entities.Address", b =>
                {
                    b.Property<string>("City")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("City");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            City = "Ho Chi Minh",
                            Street = "Bui Vien"
                        },
                        new
                        {
                            City = "Ha Noi",
                            Street = "Tran Duy Hung"
                        });
                });

            modelBuilder.Entity("Repository.Entities.Book", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AddressCity");

                    b.HasIndex("PressId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = new Guid("925823c7-b48a-44fb-9d57-b4e58165fdf6"),
                            AddressCity = "Ho Chi Minh",
                            Author = "Aristotle",
                            ISBN = "978-3-16-148410-0",
                            PressId = new Guid("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"),
                            Price = 100000.0,
                            Title = "Philosophy"
                        },
                        new
                        {
                            ID = new Guid("b2c9e028-3ca6-494c-8030-378c8999e9a6"),
                            AddressCity = "Ho Chi Minh",
                            Author = "Einstein",
                            ISBN = "978-3-16-148410-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 200000.0,
                            Title = "Physics"
                        },
                        new
                        {
                            ID = new Guid("88316682-e17d-48d4-808d-c703182f5a89"),
                            AddressCity = "Ha Noi",
                            Author = "Aristotle",
                            ISBN = "978-3-16-148410-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 150000.0,
                            Title = "Science Fiction"
                        },
                        new
                        {
                            ID = new Guid("b604bf0a-0071-43f7-9e2e-69df31c28982"),
                            AddressCity = "Ha Noi",
                            Author = "Aristotle",
                            ISBN = "978-3-16-148410-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 150000.0,
                            Title = "Science Fiction"
                        },
                        new
                        {
                            ID = new Guid("99a8785d-2dc7-4a4c-a437-a2d72ba2a603"),
                            AddressCity = "Ha Noi",
                            Author = "Stella Blackwood",
                            ISBN = "978-1-23-456789-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 87500.0,
                            Title = "The Galactic Voyage"
                        },
                        new
                        {
                            ID = new Guid("7392b7b9-d9b5-4817-b050-c625bbd94c2b"),
                            AddressCity = "Ha Noi",
                            Author = "Nathan Greenfield",
                            ISBN = "978-9-87-654321-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 203750.0,
                            Title = "Time Rift Chronicles"
                        },
                        new
                        {
                            ID = new Guid("8591a71d-d322-4143-8839-a8b264a9664e"),
                            AddressCity = "Ha Noi",
                            Author = "Erika Silverstone",
                            ISBN = "978-5-55-555555-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 121250.0,
                            Title = "Cybernetic Dreams"
                        },
                        new
                        {
                            ID = new Guid("13511bde-7439-4e91-9916-63ff9831b740"),
                            AddressCity = "Ha Noi",
                            Author = "Oliver Armstrong",
                            ISBN = "978-2-22-333333-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 185900.0,
                            Title = "Quantum Paradox"
                        },
                        new
                        {
                            ID = new Guid("9dba4c64-4bae-41e4-9860-e3a461595195"),
                            AddressCity = "Ha Noi",
                            Author = "Maya Thompson",
                            ISBN = "978-0-98-765432-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 92800.0,
                            Title = "Stellar Convergence"
                        },
                        new
                        {
                            ID = new Guid("f7d3326a-6237-49c4-b403-9f702425b5ac"),
                            AddressCity = "Ha Noi",
                            Author = "Benjamin Hartman",
                            ISBN = "978-7-77-777777-0",
                            PressId = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Price = 176300.0,
                            Title = "Galactic Empire"
                        });
                });

            modelBuilder.Entity("Repository.Entities.Press", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Presses");

                    b.HasData(
                        new
                        {
                            ID = new Guid("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"),
                            Category = 2,
                            Name = "E Book"
                        },
                        new
                        {
                            ID = new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                            Category = 1,
                            Name = "Magazine"
                        },
                        new
                        {
                            ID = new Guid("949707e7-ec5c-43b0-9d50-669a067d584f"),
                            Category = 0,
                            Name = "Book"
                        });
                });

            modelBuilder.Entity("Repository.Entities.Book", b =>
                {
                    b.HasOne("Repository.Entities.Address", "Address")
                        .WithMany("Books")
                        .HasForeignKey("AddressCity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.Press", "Press")
                        .WithMany("Books")
                        .HasForeignKey("PressId");

                    b.Navigation("Address");

                    b.Navigation("Press");
                });

            modelBuilder.Entity("Repository.Entities.Address", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Repository.Entities.Press", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
