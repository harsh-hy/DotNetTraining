using System;
namespace EnumExample
{
    public enum DaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public class EnumDemo
    {
        public void ShowDayMessage(DaysOfWeek day)
        {
            switch (day)
            {
                case DaysOfWeek.Sunday:
                    Console.WriteLine("It's Sunday! Time to relax.");
                    break;
                case DaysOfWeek.Monday:
                    Console.WriteLine("It's Monday! Back to work.");
                    break;
                case DaysOfWeek.Tuesday:
                    Console.WriteLine("It's Tuesday! Keep going.");
                    break;
                case DaysOfWeek.Wednesday:
                    Console.WriteLine("It's Wednesday! Halfway there.");
                    break;
                case DaysOfWeek.Thursday:
                    Console.WriteLine("It's Thursday! Almost the weekend.");
                    break;
                case DaysOfWeek.Friday:
                    Console.WriteLine("It's Friday! The weekend is near.");
                    break;
                case DaysOfWeek.Saturday:
                    Console.WriteLine("It's Saturday! Enjoy your day.");
                    break;
                default:
                    Console.WriteLine("Invalid day.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnumDemo demo = new EnumDemo();
            demo.ShowDayMessage(DaysOfWeek.Wednesday);
        }
    }
}