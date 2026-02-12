class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max=int.MinValue;
        int[] ar=new int[n];
        for(int i=0;i<n;i++)
            ar[i]=int.Parse(Console.ReadLine());

        for(int i=0;i<n;i++)
            max=max<ar[i]?ar[i]:max;
        Console.WriteLine(max);
    }
}