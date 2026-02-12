class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] ar=new int[n];
        for(int i=0;i<n;i++)
            ar[i]=int.Parse(Console.ReadLine());
        Dictionary<int,int> dict = new Dictionary<int,int>();
        for(int i=0;i<n;i++)
        {
            if(dict.ContainsKey(ar[i]))
                dict[ar[i]]++;
            else
                dict[ar[i]]=1;
        }
        foreach(var x in dict)
        {
            Console.WriteLine($"Freq of {x.Key} is {x.Value}");
        }
    }
}