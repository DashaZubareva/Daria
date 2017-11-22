using BikeStore.Interfaces;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.DataAccess
{
    public class BikeContext
    {
        public IRepozitory bikeRepository = new BikeRepository();
        private static IList<Bike> books;
        public static IList<Bike> instance()
        {
            if (books == null)
            {
                books = init();
            }
            return books;
        }
        private static IList<Bike> init()
        {

            IList<Bike> bookList = new List<Bike>();
            for (int i = 0; i < 10; i++)
            {
                bookList.Add(Models.Bike.build());
            }
            return bookList;
        }
    }
}