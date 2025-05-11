using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public static class DataSeeding
    {
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { ID = Guid.NewGuid(), Title = "The Silent Patient", Author = "Alex Michaelides", Quantity = 10, AvailableBooks = 10, PageCount = 336 },
                new Book { ID = Guid.NewGuid(), Title = "Educated", Author = "Tara Westover", Quantity = 8, AvailableBooks = 8, PageCount = 352 },
                new Book { ID = Guid.NewGuid(), Title = "Becoming", Author = "Michelle Obama", Quantity = 7, AvailableBooks = 7, PageCount = 448 },
                new Book { ID = Guid.NewGuid(), Title = "The Alchemist", Author = "Paulo Coelho", Quantity = 12, AvailableBooks = 12, PageCount = 208 },
                new Book { ID = Guid.NewGuid(), Title = "1984", Author = "George Orwell", Quantity = 9, AvailableBooks = 9, PageCount = 328 },
                new Book { ID = Guid.NewGuid(), Title = "Sapiens", Author = "Yuval Noah Harari", Quantity = 11, AvailableBooks = 11, PageCount = 443 },
                new Book { ID = Guid.NewGuid(), Title = "To Kill a Mockingbird", Author = "Harper Lee", Quantity = 5, AvailableBooks = 5, PageCount = 281 },
                new Book { ID = Guid.NewGuid(), Title = "Atomic Habits", Author = "James Clear", Quantity = 14, AvailableBooks = 14, PageCount = 320 },
                new Book { ID = Guid.NewGuid(), Title = "The Power of Habit", Author = "Charles Duhigg", Quantity = 13, AvailableBooks = 13, PageCount = 371 },
                new Book { ID = Guid.NewGuid(), Title = "The Hobbit", Author = "J.R.R. Tolkien", Quantity = 6, AvailableBooks = 6, PageCount = 310 },
                new Book { ID = Guid.NewGuid(), Title = "Dune", Author = "Frank Herbert", Quantity = 10, AvailableBooks = 10, PageCount = 688 },
                new Book { ID = Guid.NewGuid(), Title = "Pride and Prejudice", Author = "Jane Austen", Quantity = 8, AvailableBooks = 8, PageCount = 279 },
                new Book { ID = Guid.NewGuid(), Title = "The Catcher in the Rye", Author = "J.D. Salinger", Quantity = 7, AvailableBooks = 7, PageCount = 277 },
                new Book { ID = Guid.NewGuid(), Title = "The Book Thief", Author = "Markus Zusak", Quantity = 9, AvailableBooks = 9, PageCount = 552 },
                new Book { ID = Guid.NewGuid(), Title = "Brave New World", Author = "Aldous Huxley", Quantity = 5, AvailableBooks = 5, PageCount = 268 },
                new Book { ID = Guid.NewGuid(), Title = "The Road", Author = "Cormac McCarthy", Quantity = 6, AvailableBooks = 6, PageCount = 287 },
                new Book { ID = Guid.NewGuid(), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Quantity = 10, AvailableBooks = 10, PageCount = 180 },
                new Book { ID = Guid.NewGuid(), Title = "Moby Dick", Author = "Herman Melville", Quantity = 4, AvailableBooks = 4, PageCount = 635 },
                new Book { ID = Guid.NewGuid(), Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Quantity = 7, AvailableBooks = 7, PageCount = 671 },
                new Book { ID = Guid.NewGuid(), Title = "Frankenstein", Author = "Mary Shelley", Quantity = 8, AvailableBooks = 8, PageCount = 280 },
                new Book { ID = Guid.NewGuid(), Title = "Jane Eyre", Author = "Charlotte Brontë", Quantity = 9, AvailableBooks = 9, PageCount = 532 },
                new Book { ID = Guid.NewGuid(), Title = "Dracula", Author = "Bram Stoker", Quantity = 6, AvailableBooks = 6, PageCount = 418 },
                new Book { ID = Guid.NewGuid(), Title = "Fahrenheit 451", Author = "Ray Bradbury", Quantity = 7, AvailableBooks = 7, PageCount = 194 },
                new Book { ID = Guid.NewGuid(), Title = "The Shining", Author = "Stephen King", Quantity = 10, AvailableBooks = 10, PageCount = 447 },
                new Book { ID = Guid.NewGuid(), Title = "The Martian", Author = "Andy Weir", Quantity = 11, AvailableBooks = 11, PageCount = 369 }
             );
        }

        public static void SeedProfiles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile { ID = Guid.NewGuid(), FirstName = "John", SecondName = "Doe", Email = "john.doe@example.com", RegistrationDate = DateTime.UtcNow, isAdmin = false },
                new Profile { ID = Guid.NewGuid(), FirstName = "Jane", SecondName = "Smith", Email = "jane.smith@example.com", RegistrationDate = DateTime.UtcNow, isAdmin = false },
                new Profile { ID = Guid.NewGuid(), FirstName = "Tom", SecondName = "Jones", Email = "tom.jones@example.com", RegistrationDate = DateTime.UtcNow, isAdmin = false },
                new Profile { ID = Guid.NewGuid(), FirstName = "Alice", SecondName = "Johnson", Email = "alice.johnson@example.com", RegistrationDate = DateTime.UtcNow, isAdmin = true }
            );
        }


    }
}

