using System;
using System.Collections.Generic;
namespace bikeSt
{
    class Bike
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal PricePerDay { get; set; }
    }
    public class BikeUtility
    {
        public static SortedDictionary<int, Bike> bikeDetails = Program.bikeDetails;
        public void AddBikeDetails(string model, string brand, decimal pricePerDay)
        {
            int i = bikeDetails.Count+1;
            bikeDetails.Add(i, new Bike{
                Model=model,
                Brand=brand,
                PricePerDay=pricePerDay
            });
        }
        public SortedDictionary<string,List<Bike>>GroupBikesByBrand()
        {
            SortedDictionary<string,List<Bike>>BikeGroup = new SortedDictionary<string, List<Bike>();
            foreach(var bi in bikeDetails.Values)
            {
                if (!BikeGroup.ContainsKey(bi.Brand))
                    {
                        BikeGroup[bi.Brand] = new List<Bike>();
                    }
                BikeGroup[bi.Brand].Add(bi);
            }
            return BikeGroup;
        }
    }
}