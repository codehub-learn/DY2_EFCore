using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Synopsis> Synopsis { get; set; }
        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = localhost; Initial Catalog = DY2_EF; Integrated Security=true");
            //("Data Source = localhost; Initial Catalog = CS06_Data; User ID = User; Password = pass");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Publisher>().HasKey(p => p.PublisherKey);

            builder.Entity<Author>()
                .HasMany(a => a.Publishers)
                .WithMany(p => p.Authors)
                .UsingEntity<AuthorPublisher>
                (
                  ap => ap.HasOne<Publisher>().WithMany(),
                  ap => ap.HasOne<Author>().WithMany()
                )
                .Property(ap => ap.StartDate)
                .HasDefaultValue(DateTime.UtcNow);

            base.OnModelCreating(builder);
        }

    }
}
