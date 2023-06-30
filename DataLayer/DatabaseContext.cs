using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(book => book.Address).WithMany(address => address.Books).HasForeignKey(book => book.AddressCity);

            modelBuilder.Entity<Book>().HasOne(book => book.Press).WithMany(press => press.Books).HasForeignKey(book => book.PressId).IsRequired(false);

            User admin = new User()
            {
				Username = "admin",
				Password = "admin",
				Role = 1
			};
            User staff = new User()
            {
                Username = "staff",
                Password = "staff",
                Role = 2
            };
			User customer = new User()
			{
				Username = "customer",
				Password = "customer",
				Role = 3
			};

            modelBuilder.Entity<User>().HasData(admin, staff, customer);

            Press eBook = new Press()
            {
                ID = Guid.Parse("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"),
                Name = "E Book",
                Category = Category.EBook
            };

            Press magazine = new Press()
            {
                ID = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                Name = "Magazine",
                Category = Category.Magazine
            };

            Press book = new Press()
            {
                ID = Guid.Parse("949707e7-ec5c-43b0-9d50-669a067d584f"),
				Name = "Book",
				Category = Category.Book
			};

            modelBuilder.Entity<Press>().HasData(eBook, magazine, book);

            Address location1 = new Address()
            {
                City = "Ho Chi Minh",
                Street = "Bui Vien"
            };

            Address Location2 = new Address()
            {
				City = "Ha Noi",
				Street = "Tran Duy Hung"
			};

            modelBuilder.Entity<Address>().HasData(location1, Location2);

            Book philosophy = new Book()
            {
                ID = Guid.Parse("925823c7-b48a-44fb-9d57-b4e58165fdf6"),
                ISBN = "978-3-16-148410-0",
                Title = "Philosophy",
                Author = "Aristotle",
                Price = 100000,
				AddressCity = "Ho Chi Minh",

				PressId = Guid.Parse("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"),
            };

			Book physics = new Book()
			{
				ID = Guid.Parse("b2c9e028-3ca6-494c-8030-378c8999e9a6"),
				ISBN = "978-3-16-148410-0",
				Title = "Physics",
				Author = "Einstein",
				Price = 200000,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                AddressCity = "Ho Chi Minh"
			};

			Book scifi = new Book()
			{
				ID = Guid.Parse("88316682-e17d-48d4-808d-c703182f5a89"),
				ISBN = "978-3-16-148410-0",
				Title = "Science Fiction",
				Author = "Aristotle",
				Price = 150000,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
                AddressCity = "Ha Noi"
			};

			Book book1 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-3-16-148410-0",
				Title = "Science Fiction",
				Author = "Aristotle",
				Price = 150000,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book2 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-1-23-456789-0",
				Title = "The Galactic Voyage",
				Author = "Stella Blackwood",
				Price = 87500,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book3 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-9-87-654321-0",
				Title = "Time Rift Chronicles",
				Author = "Nathan Greenfield",
				Price = 203750,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book4 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-5-55-555555-0",
				Title = "Cybernetic Dreams",
				Author = "Erika Silverstone",
				Price = 121250,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book5 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-2-22-333333-0",
				Title = "Quantum Paradox",
				Author = "Oliver Armstrong",
				Price = 185900,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book6 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-0-98-765432-0",
				Title = "Stellar Convergence",
				Author = "Maya Thompson",
				Price = 92800,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			Book book7 = new Book()
			{
				ID = Guid.NewGuid(),
				ISBN = "978-7-77-777777-0",
				Title = "Galactic Empire",
				Author = "Benjamin Hartman",
				Price = 176300,
				PressId = Guid.Parse("d75cefaf-2361-4251-a2ff-6cbe36182899"),
				AddressCity = "Ha Noi"
			};

			modelBuilder.Entity<Book>().HasData(philosophy, physics, scifi);
			modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5, book6, book7);
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
