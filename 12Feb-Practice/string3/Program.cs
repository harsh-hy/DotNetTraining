class Program
{
    public static void Main()
    {
        string str= "1 2 3 4";
        string[] cAr=str.Split(' ');
        foreach(var x in cAr)
        {
            Console.WriteLine("str array to int "+(int.Parse(x)));
        }
        
    }
}