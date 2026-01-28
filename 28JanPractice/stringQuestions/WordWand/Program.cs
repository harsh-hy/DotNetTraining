using System;
namespace WordWand
{
    class Program
    {
        public static void Main()
        {
            string? sentence=Console.ReadLine();
            string[] ar= sentence.Split(' ');
            int EvenOrOdd=0;
            if(ar.Length%2!=0)
                EvenOrOdd=1;
            string? ans="";
            if(EvenOrOdd == 0)
            {
                for(int i=ar.Length-1;i>=0;i--)
                {
                    ans=ans+ar[i]+" ";
                }
            }
            else
            {
                for(int i=0;i<ar.Length;i++)
                {
                    string? wordStr=ar[i];
                    char[] word=wordStr.ToCharArray();
                    string? newWord="";
                    for(int j=word.Length-1;j>=0;j--)
                    {
                        newWord=newWord+word[j];
                    }
                    ans=ans+newWord+" ";
                }
            }
            Console.WriteLine("Answer: "+ans);
        }
    }
}