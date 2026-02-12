using System;
public class Test
{
    public static int PowerGame(int n, int[] ar)
    {
        int result=0;
        for(int i=0;i<n;i++)
        {
            if(result ==0)
                result = ar[i];
            else if(ar[i]>=result)
            {
                result =0;
            }
            else
            {
                result += ar[i];
            }
        }
        return result;
    }
    public static void Main()
    {
        int n=int.Parse(Console.ReadLine());
        int[] ar= new int[n];
        string[] tokens=Console.ReadLine().Split();
        for(int i=0;i<n;i++)
        {
            ar[i]=int.Parse(tokens[i]);
        }
        int ans=PowerGame(n,ar);
        if(ans==0)
            Console.WriteLine("NO");
        else
            Console.WriteLine("YES "+ans);
    }
}