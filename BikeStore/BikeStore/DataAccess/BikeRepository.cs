using BikeStore.Interfaces;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.DataAccess
{
    public class BikeRepository : IRepozitory
    {
        public static IList<Bike> bikes;
        public BikeRepository()
        {
            if (bikes == null)
                bikes = init();
        }
        private IList<Bike> init()
        {
            IList<Bike> bikeList = new List<Bike>();
            for (int i = 0; i < 22; i++)
            {
                bikeList.Add(Bike.build());
            }
            return bikeList;
        }

        public bool delete(int? bikeId)
        {
            foreach (Bike bike in bikes)
            {
                if (bike.BikeId == bikeId)
                {
                    bikes.Remove(bike);
                    return true;
                }
            }
            return true;
        }

        public IList<Bike> FindAll()
        {
            return bikes;
        }

        public Bike findBike(int bikeId)
        {
            return bikes.FirstOrDefault(bike => bike.BikeId == bikeId);
        }
        public IList<Bike> searchBikes(string names)
        {
            IList<Bike> findedBikes = new List<Bike>();
            foreach (Bike bike in bikes)
            {
                if (bike.BikeName.IndexOf(names) > 0)
                {
                    findedBikes.Add(bike);
                }
            }
            return findedBikes;
        }
        public bool update(Bike bikeForUpdate)
        {
            foreach (Bike bike in bikes)
            {
                if (bike.BikeId == bikeForUpdate.BikeId)
                {
                    bike.BikeName = bikeForUpdate.BikeName;
                    bike.BikePrice = bikeForUpdate.BikePrice;
                    bike.BikeSpeed = bikeForUpdate.BikeSpeed;
                    bike.BikeWheel = bikeForUpdate.BikeWheel;
                    return true;
                }
            }
            return false;
        }
        public IList<Bike> addBook(Bike bikeToAdd)
        {
            bikes.Add(bikeToAdd);
            return bikes;
        }
    }
}