using ConsoleApp3;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//Author eco = new Author()
//{
//    FirstName = "Umbero",
//    LastName = "Eco"
//};

//Book Pendulum = new Book()
//{
//    Title = "Foucault's Pendulum",
//    PubDate = new DateTime(1988, 3, 15),
//    Pages = 750,
//    Author = eco
//};

//Book Prague = new Book()
//{
//    Title = "Prague Cemetary",
//    PubDate = new DateTime(2010, 3, 15),
//    Pages = 750,
//    Author = eco
//};


using BooksContext context = new BooksContext();
//context.Authors.Add(eco);
//context.Books.AddRange(Pendulum, Prague);
//context.SaveChanges();

//IQueryable<Book> books = context.Books.Include(book => book.Author);
//List<Book> booksList = books.ToList();
//foreach (Book book in booksList)
//{
//    Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}");
//}

//Book limits = new Book()
//{
//    Title = "The limits of interpretation",
//    Author = context.Authors.First(a => a.LastName == "Eco"),
//    Pages = 260,
//    Synopsis = new Synopsis() { WriterFirstName = "John", WriterLastName = "Smith" }
//};

//Genre Philosophy = new() { Name = "Philosophy", Finction = false };
//Genre Historical = new() { Name = "Historical", Finction = false };

//Book nameoftherose = new Book()
//{
//    Title = "The name of the rose",
//    Author = context.Authors.First(a => a.LastName == "Eco"),
//    Pages = 500,
//    Synopsis = new Synopsis() { WriterFirstName = "Anna", WriterLastName = "Smith" },
//    Genres = new() { Philosophy, Historical }
//};

//Book page0 = new Book()
//{
//    Title = "Page 0",
//    Author = context.Authors.First(a => a.LastName == "Eco"),
//    Pages = 500,
//    Synopsis = new Synopsis() { WriterFirstName = "Anna", WriterLastName = "Smith" },
//    Genres = context.Genres
//        .Where(g => g.Name == "Philosophy" || g.Name == "Historical")
//        .ToList()
//};

//context.Add(page0);
//context.SaveChanges();

//Genre mystery = new() { Name = "Mystery", Finction = false };
//context.Genres.Add(mystery);

//Book page0q = context.Books.First(b => b.Title == "Page 0");
//page0q.Genres.Add(mystery);
//context.SaveChanges();

//Book page02 = context.Books
//    .Include(book => book.Genres)
//    .Include(book => book.Author)
//    .Include(book => book.Synopsis)
//    .First(b => b.Title == "Page 0");

//string page02authorfn = page02.Author.FirstName;
//List<Genre> page02genres = page02.Genres.ToList();
//foreach (Genre genre in page02genres)
//{
//    Console.WriteLine(genre.Name);
//}

//Author eco = context.Authors.First(a => a.LastName == "Eco");
//eco.FirstName = "Umberto";
//context.Update(eco);
//context.SaveChanges();


//context.Add(nameoftherose);

Console.WriteLine();

//context.Books.Add(limits);
//context.SaveChanges();

//Genre marketing = new Genre() { Name = "Marketing", Finction = false };
//context.Genres.Add(marketing);
//context.SaveChanges();

//Genre mareketingq = context.Genres.Where(g => g.Name == "Marketing").First();
//Book book2 = new Book()
//{
//    Title = "Marketing Managemnet",
//    Author = new Author() { FirstName = "Peter", LastName = "kotler" },
//    Genres = context.Genres.Where(g => g.Name == "Marketing" || g.Name == "Mystery").ToList(),
//};

//Book marketingpmngement = context.Books
//    .Include(b => b.Genres)
//    .First(b => b.Title == "Marketing Managemnet");

//marketingpmngement.Genres.Add(context.Genres.First(g => g.Name == "Historical"));
//context.SaveChanges();

//Publisher fixedHouse = new Publisher() { Name = "Fixed House", Language = "English" };
//Publisher dolceVita = new Publisher() { Name = "Dolce Vita", Language = "Italian" };
//context.Publishers.AddRange(fixedHouse, dolceVita);

//Author eco = context.Authors.Include(a => a.Publishers).First(b => b.LastName == "Eco");
//eco.Publishers.AddRange(new List<Publisher>() { fixedHouse, dolceVita });
//context.SaveChanges();

List<Book> books = context.Books.ToList(); //All books without related entities
List<Book> booksPlus = context.Books //All books With related entities
    .Include(b => b.Author)
    .Include(b => b.Synopsis)
    .Include(b => b.Genres)
    .OrderBy(b => b.Title)
    .ToList();
List<Book> booksDistinct = context.Books.Distinct().ToList(); //Distinct Books
List<string> bookTilesDistinct = context.Books.Select(b => b.Title).Distinct().ToList(); //Distinct Titles

Book foucaults = context.Books.Where(b => b.Title == "Foucault's Pendulum").First(); //Finds first object
Book foucaults2 = context.Books.Where(b => b.Title == "Foucault's Pendulum").Single(); //Must find only one object
Book foucaults3 = context.Books.Where(b => b.Title == "Foucault's Pendulum").FirstOrDefault(); //Will return one object or null
Book foucaults4 = context.Books.Where(b => b.Title == "Foucault's Pendulum").SingleOrDefault(); //Will return one object or null

var authorPub = context.Set<AuthorPublisher>()
    .Where(ap => ap.AuthorId ==1 && ap.PublisherPublisherKey == 1)
    .SingleOrDefault();

List<Publisher> pubs = context.Publishers.Include(p => p.Authors).ToList();
List<Author> authors2 = context.Authors.Include(p => p.Publishers).ToList();

authorPub.StartDate = new DateTime(1999, 1, 1);
context.SaveChanges();

Console.WriteLine();