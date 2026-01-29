using System;
namespace HotelBillingSystem;
{
    interface IRoom
    {
        double CalculateBill(int nightStayed, int joiningYear)
        int CalculateMembershipYears(int joiningYear)
        {
            int currentYear=DateTime.Now.Year;
            return currentYear-joiningYear;
        }
    }
    Class HotelRoom:IRoom
    {
        private string roomType;
        private double ratePerNight;
        private string guestName;
        public HotelRoom(string roomType, double ratePerNight, string guestName)
        {
            this.roomType = roomType;
            this.ratePerNight = ratePerNight;
            this.guestName = guestName;
        }
        public double CalculateTotalBill(int nightsStayed, int joiningYear)
        {
            double totalBill = nightsStayed * ratePerNight;
            int membershipYears = CalculateMembershipYears(joiningYear);
            if (membershipYears > 3)
            {
                totalBill *= 0.90;
            }
            return Math.Round(totalBill);
        } 
    }
}