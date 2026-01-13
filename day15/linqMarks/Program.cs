using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace markss
{
    class MarksLinq
    {
        public int rno { get; set; }
        public int m1 { get; set; }
        public int m2 { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<MarksLinq> students = new List<MarksLinq>()
            {
                new MarksLinq{ rno = 101, m1 = 80, m2 = 90 },
                new MarksLinq{ rno = 102, m1 = 60, m2 = 70 },
                new MarksLinq{ rno = 103, m1 = 95, m2 = 85 },
                new MarksLinq{ rno = 104, m1 = 40, m2 = 50 }
            };

            //LINQ: sort by average ascending
            var result = from s in students
                         orderby (s.m1 + s.m2) / 2.0
                         select new
                         {
                             s.rno,
                             Avg = (s.m1 + s.m2) / 2.0
                         };

            Console.WriteLine("Rno based on Average marks :\n");

            foreach (var s in result)
                Console.WriteLine($"Rno: {s.rno}  Average: {s.Avg:F2}");
        }
    }
}