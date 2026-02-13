using System;
using System.Collections.Generic;
public class Jewellery
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string Material { get; set; }
    public int Price { get; set; }
}
public class JewelleryUtility
{
    public Dictionary<string, string> GetJewelleryDetails(string id)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach(var item in Program.jewelleryDetails)
        {
            if(item.Value.Id == id){
                string value=item.Value.Type+"-"+item.Value.Material;
                result.Add(id,value);
                return result;
            }
        }
        return result;
    }
    public Dictionary<string, Jewellery> UpdateJewelleryPrice(string id, int price)
    {
        Dictionary<string, Jewellery> result = new Dictionary<string, Jewellery>();
        foreach (var item in Program.jewelleryDetails)
        {
            if (item.Value.Id == id)
            {
                item.Value.Price = price;
                result.Add(id, item.Value);
                return result;
            }
        }
        return result;
    }
}
public class Program
{
    public static Dictionary<int, Jewellery> jewelleryDetails = new Dictionary<int, Jewellery>()
        {
            {1, new Jewellery{ Id="JW01", Type="Chain", Material="Gold", Price=7985}},
            {2, new Jewellery{ Id="JW02", Type="Ring", Material="Gold", Price=9335}},
            {3, new Jewellery{ Id="JW03", Type="Necklace", Material="Gold", Price=8318}}
        };
    public static void Main(string[] args)
    {
        JewelleryUtility util = new JewelleryUtility();
        int choice = 0;
        while (choice!=3)
        {
            Console.WriteLine("1.Get Jewellery Details");
            Console.WriteLine("2.Update Price");
            Console.WriteLine("3.Exit");
            Console.Write("Enter your choice");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the jewellery id");
                string id = Console.ReadLine();
                var res = util.GetJewelleryDetails(id);
                if (res.Count == 0)
                {
                    Console.WriteLine("Jewellery id not found");
                }
                else
                {
                    foreach (var item in res)
                    {
                        Console.WriteLine(item.Key + "   " + item.Value);
                    }
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the jewellery id");
                string id = Console.ReadLine();
                Console.WriteLine("Enter the price to be updated");
                int price = int.Parse(Console.ReadLine());
                var res = util.UpdateJewelleryPrice(id, price);
                if (res.Count == 0)
                {
                    Console.WriteLine("Jewellery id not found");
                }
                else
                {
                    foreach (var item in res)
                    {
                        Jewellery j = item.Value;
                        Console.WriteLine("Id: " + j.Id +",Type: " + j.Type +",Material: "+j.Material+",Price: " +j.Price);
                    }
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Thank you");
            }
            else
            {
                Console.WriteLine("Wrong Input!!");
            }
        } 
    }
}