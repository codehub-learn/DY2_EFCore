﻿using ConsoleApp3;
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

IQueryable<Book> books = context.Books.Include(book => book.Author);
List<Book> booksList = books.ToList();
foreach (Book book in booksList)
{
    Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}");
}

//Book limits = new Book()
//{
//    Title = "The limits of interpretation",
//    Author = context.Authors.First(a => a.LastName == "Eco"),
//    Pages = 260,
//    Synopsis = new Synopsis() { WriterFirstName = "John", WriterLastName = "Smith" }
//};

List<Book> limitsquery = context.Books.Include(b => b.Synopsis).ToList();

Console.WriteLine();

//context.Books.Add(limits);
//context.SaveChanges();


