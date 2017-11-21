using DemoMVC.Models;
using System;
using System.Collections.Generic;

namespace DemoMVC.Interfaces
{
    public interface IRepozitory
    {
        IList<Book> findAll();
        Book findBook(int bookId);
        IList<Book> searchBooks(string names);
        bool update(Book book);
        bool delete(int? bookId);
        IList<Book> addBook(Book book);
    }
}
