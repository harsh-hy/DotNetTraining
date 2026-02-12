class Program
{
    public static void Main(string[] args)
    {
        string str=Console.ReadLine();
        int n= str.Length;
        int j=n-1;
        char[] charArr=str.ToCharArray();
        bool isPalindrome=true;
        for (int i=0 ;i<n;i++)
        {
            if(charArr[i]!=charArr[j])
                isPalindrome = false;
            j--;
        }
        Console.WriteLine(isPalindrome);
    }
}