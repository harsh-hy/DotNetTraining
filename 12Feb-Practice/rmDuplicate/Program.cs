class Program
{
    public static void Main()
    {
        string str= Console.ReadLine();
        char[] ar = str.ToCharArray();
        HashSet<char> st = new HashSet<char>(str);
        string result = new string(new List<char>(st).ToArray());
        Console.WriteLine(result);
    }
}