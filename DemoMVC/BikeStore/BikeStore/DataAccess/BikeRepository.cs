using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.DataAccess
{
    public class BikeRepository
    {
        private static IList<Bike> bikes;
        public BikeRepository()
        {
            if (bikes == null)
                bikes = init();
        }
        private IList<Bike> init()
        {

            IList<Bike> bookList = new List<Bike>();
            for (int i = 0; i < 10; i++)
            {
                bookList.Add(Models.Book.build());
            }
            return bookList;
        }

        public bool delete(int? bookId)
        {
            foreach (Bike bookk in _books)
            {
                if (bookk.ID == bookId)
                {
                    _books.Remove(bookk);
                    return true;
                }
            }
            return true;
        }

        public IList<Bike> findAll()
        {
            return _books;
        }

        public Bike findBook(int bookId)
        {
            return _books.FirstOrDefault(book => book.ID == bookId);
        }

        public IList<v> searchBooks(string names)
        {
            IList<Bike> findedBooks = new List<Bike>();
            foreach (Bike bookk in _books)
            {
                if (bookk.BookName.IndexOf(names) > 0)
                {
                    findedBooks.Add(bookk);
                }
            }
            return findedBooks;

        }

        public bool update(Bike book)
        {

            foreach (Bike bookk in _books)
            {
                if (bookk.ID == book.ID)
                {
                    bookk.BookName = book.BookName;
                    bookk.Author = book.Author;
                    bookk.Price = book.Price;
                    bookk.isPrezent = book.isPrezent;
                    return true;
                }
            }
            return false;

        }
        public IList<Bike> addBook(Bike book)
        {
            _books.Add(book);
            return _books;

        }

    }
}