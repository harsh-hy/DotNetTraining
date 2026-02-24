using System;
using System.Collections.Generic;
using Application;
using Domain;
public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] data = input.Split(' ');
        Book book = new Book();
        book.Id = data[0];
        book.Title = data[1];
        book.Price = int.Parse(data[2]);
        book.Stock = int.Parse(data[3]);
        BookUtility util = new BookUtility(book);

        while(true)
        {
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                util.GetBookDetails();
            }
            else if(choice == 2)
            {
                int newPrice = int.Parse(Console.ReadLine());
                util.UpdateBookPrice(newPrice);
            }
            else if(choice == 3)
            {
                int newStock = int.Parse(Console.ReadLine());
                util.UpdateBookStock(newStock);
            }
            else if(choice == 4)
            {
                Console.WriteLine("Thank You");
                break;
            }
        }
    }
}
