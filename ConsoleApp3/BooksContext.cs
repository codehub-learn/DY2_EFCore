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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source = localhost; Initial Catalog = DY2_EF; Integrated Security=true");
            //("Data Source = localhost; Initial Catalog = CS06_Data; User ID = User; Password = pass");
        }


    }
}
