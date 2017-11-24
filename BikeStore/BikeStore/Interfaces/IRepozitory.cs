using BikeStore.Models;
using System;
using System.Collections.Generic;


namespace BikeStore.Interfaces
{
   public interface IRepozitory
    {
        IList<Bike> FindAll();
        Bike findBike(int bookId);
        IList<Bike> searchBikes(string names);
        bool update(Bike book);
        bool delete(int? bookId);
        IList<Bike> addBook(Bike book);
    }
}
