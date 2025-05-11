using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public class LibrarySystemDbContext : DbContext
    { 
        public DbSet<Book> Books { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<BookRecord> BookRecords { get; set; }
        public DbSet<RemovedBook> RemovedBooks { get; set; }

        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookRecord>()
            .HasKey(b => b.ID);

          
            modelBuilder.Entity<BookRecord>()
                .HasOne(b => b.Profile)
                .WithMany(p => p.BookRecords)
                .HasForeignKey(b => b.ProfileID);

            modelBuilder.Entity<BookRecord>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.BookRecords)
                .HasForeignKey(b => b.BookID);

            modelBuilder.Entity<RemovedBook>()
            .HasOne(db => db.Book)
            .WithOne(b => b.RemovedBooks)
            .HasForeignKey<RemovedBook>(db => db.ID)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedBooks();
            modelBuilder.SeedProfiles();
        }

    }
}
