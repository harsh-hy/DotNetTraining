using System;
using Application;

namespace Presentation;

class Program
{
    static void Main()
    {
        HotelManager manager = new HotelManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Room");
            Console.WriteLine("2. Display Available Rooms Grouped by Type");
            Console.WriteLine("3. Book Room");
            Console.WriteLine("4. Find Rooms by Price Range");
            Console.WriteLine("5. CheckOut Room");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Room Number: ");
                    int roomNumber = int.Parse(Console.ReadLine());

                    Console.Write("Room Type (Single/Double/Suite): ");
                    string type = Console.ReadLine();

                    Console.Write("Price Per Night: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddRoom(roomNumber, type, price);
                    Console.WriteLine("Room added (if room number was unique).");
                    break;

                case "2":
                    var groupedRooms = manager.GroupRoomsByType();
                    foreach (var group in groupedRooms)
                    {
                        Console.WriteLine($"\nType: {group.Key}");
                        foreach (var room in group.Value)
                        {
                            Console.WriteLine($"Room {room.RoomNumber} - ₹{room.PricePerNight}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Room Number to Book: ");
                    int bookRoomNumber = int.Parse(Console.ReadLine());

                    Console.Write("Number of Nights: ");
                    int nights = int.Parse(Console.ReadLine());

                    if (!manager.BookRoom(bookRoomNumber, nights))
                        Console.WriteLine("Room not available or does not exist.");
                    break;

                case "4":
                    Console.Write("Minimum Price: ");
                    double min = double.Parse(Console.ReadLine());

                    Console.Write("Maximum Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var rooms = manager.GetAvailableRoomsByPriceRange(min, max);
                    foreach (var room in rooms)
                    {
                        Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - ₹{room.PricePerNight}");
                    }
                    break;
                case "5":
                    Console.Write("Enter the room to be checked out from: ");
                    int checkOutRoom=int.Parse(Console.ReadLine());

                    if (!manager.CheckoutRoom(checkOutRoom))
                        Console.WriteLine("Room is not currently booked or does not exist.");
                    else
                        Console.WriteLine("Room checked out successfully.");
                    break;
                case "6":
                    return;
            }
        }
    }
}
