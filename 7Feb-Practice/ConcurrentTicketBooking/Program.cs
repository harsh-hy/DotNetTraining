using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
public class Seat
{
    public int SeatNo{get;set;}
    public bool IsBooked{get;set;}
}
public class TicketBookingSystem
{
    private Dictionary<int,Seat> seats=new Dictionary<int,Seat>();
    private object Lock =new object();
    public TicketBookingSystem(int totalSeats)
    {
        for(int i=1;i<=totalSeats;i++)
        {
            seats[i]=new Seat{SeatNo=i,IsBooked=false};
        }
    }
    public bool BookSeat(int seatNo)
    {
        lock(Lock)
        {
            if(seats[seatNo].IsBooked==false)
            {
                seats[seatNo].IsBooked=true;
                return true;
            }
            return false;
        }
    }
}
class Program
{
    public static void Main()
    {
        TicketBookingSystem system = new TicketBookingSystem(1);
        Thread t1 = new Thread(() =>
        {
            bool result = system.BookSeat(1);
            Console.WriteLine("User-A booking: " + result);
        });
        Thread t2 = new Thread(() =>
        {
            bool result = system.BookSeat(1);
            Console.WriteLine("User-B booking: " + result);
        });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}