using BikeStore.Enums;
using BikeStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Bike
    {       
        public int BikeId { get; set; }
        public string BikeName { get; set; }
        public string BikeCategory{ get; set; }
        public int BikeWheel { get; set; }
        public int BikeSpeed { get; set; }
        public decimal BikePrice { get; set; }

        private static Random random = new Random();
        public Bike build()
        {
            int index = random.Next(1, 100);
            int speedVal = random.Next(10, 30);
            int wheellVal = random.Next(3, 14);
            double PriceVal = random.Next(500, 5000);

            return new Bike
            {
                BikeId = index,
                BikeName = UtilForBike.ModelsBike[random.Next(0, 12)],
                BikeCategory = EnumCategory.1;


            }
        }

    }
}