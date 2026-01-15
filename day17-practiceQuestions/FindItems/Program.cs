using System;
using System.Collections.Generic;
namespace FindItems
{
    class Program
    {
        public static SortedDictionary<string?, long> itemDetails = new SortedDictionary<string?, long>();
        public SortedDictionary<string?, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string?, long> result = new SortedDictionary<string?, long>();
            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                    result[item.Key] = item.Value;
            }
            return result;
        }
        public List<string?> FindMinAndMaxSoldItems()
        {
            List<string?> result = new List<string?>();
            long min = long.MaxValue;
            long max = long.MinValue;
            string minItem = "";
            string maxItem = "";
            foreach (var item in itemDetails)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                    minItem = item.Key;
                }
                if (item.Value > max)
                {
                    max = item.Value;
                    maxItem = item.Key;
                }
            }
            result.Add(minItem);
            result.Add(maxItem);
            return result;
        }
        public Dictionary<string?, long> SortByCount()
        {
            Dictionary<string?, long> result = new Dictionary<string?, long>();
            foreach (var item in itemDetails.OrderBy(x => x.Value))
            {
                result[item.Key] = item.Value;
            }
            return result;
        }
        public static void Main()
        {
            Program p = new Program();
            Console.WriteLine("Enter number of items:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter item name:");
                string? itemName = Console.ReadLine();
                Console.WriteLine("Enter sold item count:");
                long soldCount = long.Parse(Console.ReadLine());
                itemDetails[itemName] = soldCount;
            }
            Console.WriteLine("Enter sold count to search:");
            long searchSoldCount = long.Parse(Console.ReadLine());
            var foundItems = p.FindItemDetails(searchSoldCount);
            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                foreach (var item in foundItems)
                {
                    Console.WriteLine(item.Key + ":" + item.Value);
                }
            }
            var minMax = p.FindMinAndMaxSoldItems();
            Console.WriteLine("min = " + minMax[0]);
            Console.WriteLine("max = " + minMax[1]);
            var sorted = p.SortByCount();
            Console.WriteLine("Sorted items");
            foreach (var item in sorted)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
        }
    }
}
