using System;
using System.Collections.Generic;
namespace HeavenHomes
{
    class Apartment
    {
        public Dictionary<string,double>apartmentDetailsMap=new Dictionary<string,double>();
        public void AddApartmentDetails(string apartmentNumber, double rent)
        {
            apartmentDetailsMap[apartmentNumber]=rent;
        }
        public double FindTotalRentOfApartmentsInTheGivenRange(double minimumRent,double maximumRent)
        {
            double result=0;
            foreach(var XRent in apartmentDetailsMap)
            {
                if(XRent.Value>=minimumRent&&XRent.Value<=maximumRent)
                    result+=XRent.Value;
            }
            return result;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Apartment AP = new Apartment();
            Console.WriteLine("Enter number of details to be added");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the details (Apartment number: Rent)");
            for(int i=0;i<n;i++)
            {
                string str=Console.ReadLine();
                string[] parts=str.Split(':');
                AP.AddApartmentDetails(parts[0],double.Parse(parts[1]));
            }
            Console.WriteLine("Enter the range to filter the details Minimum then maximum");
            double min=double.Parse(Console.ReadLine());
            double max=double.Parse(Console.ReadLine());
            double ans=AP.FindTotalRentOfApartmentsInTheGivenRange(min,max);
            Console.WriteLine($"Total Rent in the range {min} to {max} USD:{ans}");
        }
    }
}