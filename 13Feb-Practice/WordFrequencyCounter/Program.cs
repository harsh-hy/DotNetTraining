class Program
{
    public static void Main()
    {
        string str= "hello hi hello hi hello Hi my name is Hello";
        str = str.ToLower();
        Dictionary<string,int> freq = new Dictionary<string,int>();
        string[] ar = str.Split(' ');
        foreach(string ele in ar)
        {
            if(freq.ContainsKey(ele))
                freq[ele]++;
            else
                freq[ele]=1;
        }
        foreach(var element in freq)
        {
            Console.WriteLine($"Freq of {element.Key} is {element.Value}");
        }
    }
}