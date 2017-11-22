using BikeStore.Enums;
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
        public EnumCategory BikeCategory{ get; set; }
        public int BikeWheel { get; set; }
        public int BikeSpeed { get; set; }
        public decimal BikePrice { get; set; }

        public IList<Bike> build()
        {
            IList<Bike> bikes = new IList<Bike>();
            return 
        }

    }
}