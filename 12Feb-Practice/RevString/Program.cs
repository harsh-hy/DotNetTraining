class Program
{
    public static void Main()
    {
        string str= Console.ReadLine();
        string rev="";
        for(int i=str.Length-1;i>=0;i--)
            rev=rev+str[i];
        Console.WriteLine(rev);
    }
}