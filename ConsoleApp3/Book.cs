using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public int? Pages { get; set; } 
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Synopsis? Synopsis { get; set; }
    }
}
