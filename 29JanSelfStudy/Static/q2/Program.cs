using System;
class Message
{
     public void Show(string msg)
     {
        Console.WriteLine(msg);
     }
     public void Show(string msg, int times)
     {
        for(int i=0;i<times;i++)
            Console.WriteLine(msg+" "+(i+1));
     }
     public static void Main()
     {
        Message obj = new Message();
        obj.Show("hello");
        obj.Show("hi",5);
     }
}