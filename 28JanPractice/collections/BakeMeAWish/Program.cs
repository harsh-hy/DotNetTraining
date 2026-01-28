using System;
using System.Collections.Generic;
namespace BakeAWish
{
    class CakeOrder
    {
        public Dictionary<string , double> orderMap = new Dictionary<string,double>();
        public void AddOrderDetails (string orderId, double cakeCost)
        {
            orderMap[orderId]=cakeCost;
        }
        public Dictionary<string, double> FindOrdersAboveSpecifiedCost(double cakeCost)
        {
            Dictionary<string,double> result=new Dictionary<string,double>();
            foreach(var cake in orderMap)
            {
                if(cake.Value>cakeCost)
                result.Add(cake.Key,cake.Value);
            }
            return result;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            CakeOrder cakeOrder= new CakeOrder();
            Console.WriteLine("Enter number of cake orders to be added");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");
            for(int i=0;i<n;i++)
            {
                string str=Console.ReadLine();
                string[] parts=str.Split(':');
                cakeOrder.AddOrderDetails(parts[0],double.Parse(parts[1]));
            }
            Console.WriteLine("Enter the cost to search the cake orders");
            double costOfXItem=double.Parse(Console.ReadLine());
            Dictionary<string,double> cakeOfXCost = new Dictionary<string,double>();
            cakeOfXCost = cakeOrder.FindOrdersAboveSpecifiedCost(costOfXItem);
            if(cakeOfXCost.Count==0)
                Console.WriteLine("NO cake orders found");
            else
            {
                foreach(var item in cakeOfXCost)
                {
                    Console.WriteLine($"Order ID: {item.Key}, Cake Cost: {item.Value}");
                }
            }
        }
    }
}