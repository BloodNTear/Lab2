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
    [Migration("20230622091855_seed-books")]
    partial class seedbooks
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
