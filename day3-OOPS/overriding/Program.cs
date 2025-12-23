using System;

namespace OopsSession
{
    public class Father
    {
        public virtual string InterestOn()
        {
            return "Playing cricket";
        }
    }

    public class Son : Father
    {
        public override string InterestOn()
        {
            return "Playing football";
        }
    }

    class Program
    {
        static void Main()
        {
            Father father = new Father();
            Father son = new Son();   // polymorphism

            Console.WriteLine("Father's interest: " + father.InterestOn());
            Console.WriteLine("Son's interest: " + son.InterestOn());
        }
    }
}
