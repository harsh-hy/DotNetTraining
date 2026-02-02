using System;
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}
class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing shape");
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Shape s = new Circle();
        s.Draw();
    }
}