using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application;

public class HotelManager
{
    private List<Room> rooms = new List<Room>();
    public void AddRoom(int roomNumber, string type, double price)
    {
        if (rooms.Any(r => r.RoomNumber == roomNumber))
            return;
        rooms.Add(new Room
        {
            RoomNumber = roomNumber,
            RoomType = type,
            PricePerNight = price,
            IsAvailable = true
        });
    }
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        return rooms
            .Where(r => r.IsAvailable)
            .GroupBy(r => r.RoomType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
    public bool BookRoom(int roomNumber, int nights)
    {
        Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
        if (room == null)
            return false;
        double totalCost = room.PricePerNight * nights;
        room.IsAvailable = false;
        System.Console.WriteLine($"Room {roomNumber} booked. Total Cost: ₹{totalCost}");
        return true;
    }
    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        return rooms
            .Where(r => r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
            .ToList();
    }
    public bool CheckoutRoom(int roomNumber)
    {
        Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.IsAvailable);
        if (room == null)
            return false;
        room.IsAvailable = true;
        return true;
    }
}
