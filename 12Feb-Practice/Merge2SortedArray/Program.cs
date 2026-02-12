class Program
{
    public static void Main()
    {
        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("M: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("elements of N: ");
        int[] ar1=new int[n];
        for(int a=0;a<n;a++)
        {
            ar1[a]=int.Parse(Console.ReadLine());
        }
        
        Console.Write("elements of M: ");
        int[] ar2=new int[m];
        for(int b=0;b<m;b++)
        {
            ar2[b]=int.Parse(Console.ReadLine());
        }

        int max=n>m?n:m;
        int min=n+m-max;
        int i=0,j=0,k=0;
        int[] newAr = new int[n+m];
        while(i<n&&j<m)
        {
            if(ar1[i]<ar2[j])
            {
                newAr[k]=ar1[i];
                k++;
                i++;
            }
            if(ar1[i]>ar2[j])
            {
                newAr[k]=ar2[j];
                k++;
                j++;
            }
        }
        while(i<n)
        {
            newAr[k]=ar1[i];
            k++;
            i++;
        }
        while(j<m)
        {
            newAr[k]=ar2[j];
            k++;
            j++;
        }
        foreach(int x in newAr)
            Console.Write(x+" ");
    }
}