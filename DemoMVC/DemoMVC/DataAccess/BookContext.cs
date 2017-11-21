
using DemoMVC.Interfaces;
using DemoMVC.Models;
using System;
using System.Collections.Generic;


namespace DemoMVC.DataAccess
{
    public class BookContext
    {
    
        public  IRepozitory bookRepozitory = new BookRepozitory();
        private static IList<Book> books;
        public static IList<Book> instance()
        {
            if (books == null)
            {
                books = init();
            }
            return books;
        }
        private static IList<Book> init() {

            IList<Book> bookList = new List<Book>();
            for (int i=0; i<10; i++)
            {
                bookList.Add(Models.Book.build());
            }
            return bookList;
        }
    }
}