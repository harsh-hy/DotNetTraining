using System;
namespace HotelBillingSystem;
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Deluxe Room Details:");
            Console.Write("Guest Name: ");
            string deluxeGuestName = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double deluxeRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int deluxeNights = Convert.ToInt32(Console.ReadLine());
            Console.Write("Joining Year: ");
            int deluxeJoiningYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Suite Room Details:");
            Console.Write("Guest Name: ");
            string suiteGuestName = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double suiteRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int suiteNights = Convert.ToInt32(Console.ReadLine());
            Console.Write("Joining Year: ");
            int suiteJoiningYear = Convert.ToInt32(Console.ReadLine());
            HotelRoom deluxeRoom = new HotelRoom("Deluxe", deluxeRate, deluxeGuestName);
            HotelRoom suiteRoom = new HotelRoom("Suite", suiteRate, suiteGuestName);
            int deluxeMembershipYears = deluxeRoom.CalculateMembershipYears(deluxeJoiningYear);
            int suiteMembershipYears = suiteRoom.CalculateMembershipYears(suiteJoiningYear);
            double deluxeBill = deluxeRoom.CalculateTotalBill(deluxeNights, deluxeJoiningYear);
            double suiteBill = suiteRoom.CalculateTotalBill(suiteNights, suiteJoiningYear);
            Console.WriteLine("Room Summary:");
            Console.WriteLine($"Deluxe Room: {deluxeGuestName}, {deluxeRate} per night, Membership: {deluxeMembershipYears} years");
            Console.WriteLine($"Suite Room: {suiteGuestName}, {suiteRate} per night, Membership: {suiteMembershipYears} years");
            Console.WriteLine("Total Bill:");
            Console.WriteLine($"For {deluxeGuestName} (Deluxe): {deluxeBill}");
            Console.WriteLine($"For {suiteGuestName} (Suite): {suiteBill}");
        }
    }
}