class Program
{
    public static void Main()
    {
        string str= "9.5 9.3 12.4";
        string[] ar = str.Split(' ');
        List<double> li=new List<double>();
        foreach(var ch in ar)
        {
            double x = double.Parse(ch);
            li.Add(x);
        }
        foreach(var x in li)
        {
            Console.WriteLine(x+" ");
        }
    }
}