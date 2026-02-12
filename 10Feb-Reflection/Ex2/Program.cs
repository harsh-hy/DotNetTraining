using System.Reflection;
public class Adder
{
    public void Add(int a,int b)
    {
        Console.WriteLine(a+b);
    }
}
public class Program
{
    public static void Main()
    {
        Type t = typeof(Adder);               // Get type
        object obj = Activator.CreateInstance(t); //  Create instance
        MethodInfo method = t.GetMethod("Add");   //  Get method
        method.Invoke(obj, new object[] { 10, 20 }); // Call method
    }
}