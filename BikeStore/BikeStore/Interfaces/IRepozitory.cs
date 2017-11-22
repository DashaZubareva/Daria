using BikeStore.Models;
using System;
using System.Collections.Generic;


namespace BikeStore.Interfaces
{
    interface IRepozitory
    {
        IList<Bike> findAll();
        Bike findBook(int bookId);
        IList<Bike> searchBooks(string names);
        bool update(Bike book);
        bool delete(int? bookId);
        IList<Bike> addBook(Bike book);
    }
}
