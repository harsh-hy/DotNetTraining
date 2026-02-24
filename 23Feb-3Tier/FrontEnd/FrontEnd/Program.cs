using System;
using BuisnessLogic;

namespace FrontEnd
{
    class Program
    {
        static void Main()
        {
            BL bl = new BL();

            string result = bl.GetData();

            Console.WriteLine(result);
        }
    }
}