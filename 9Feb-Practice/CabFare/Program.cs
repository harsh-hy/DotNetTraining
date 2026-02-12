public class Cab
{
    public virtual int CalculateFare(int km)
    {
        return 0;
    }
}
public class Mini:Cab
{
    public override int CalculateFare(int km)
    {
        return km*12;
    }
}
public class Sedan:Cab
{
    public override int CalculateFare(int km)
    {
        return km*15+50;
    }
}
public class SUV:Cab
{
    public override int CalculateFare(int km)
    {
        return km*18+100;
    }
}
public class Program
{
    public static void Main()
    {
        Cab c1= new Mini();
        Console.WriteLine(c1.CalculateFare(10));
        Cab c2= new Sedan();
        Console.WriteLine(c2.CalculateFare(10));
        Cab c3= new SUV();
        Console.WriteLine(c3.CalculateFare(10));
    }
}