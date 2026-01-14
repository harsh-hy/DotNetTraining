using System;
using System.Threading;
namespace abcd
{
    class Program{
        public static void Main()
        {
            ThreadStart threadStart = new ThreadStart(RunStep2);
            Thread t1 = new Thread(threadStart);
            t1.Start();
            for(int i=0;i<100; i++){
                Thread.Sleep(150);
                Console.Write($"hello from main  {i+1} ");
            }
            Console.WriteLine("finish1");
            
        }
        private static void RunStep2()
        {
            for(int i=0;i<100; i++){
                Thread.Sleep(150);
                Console.WriteLine($"hello from runStep{i+1} ");
            }
            Console.WriteLine("finish2");
        }
    }   
}