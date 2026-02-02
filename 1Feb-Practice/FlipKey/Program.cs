using System;
using System.Linq;
class FlipKey
{
    public static string CleanseAndInvert(string input)
    {
        string str= input;
        if( string.IsNullOrEmpty(str) || str.Length<6)
        {
            return "";
        }
        str = str.ToLower();
        char[] ar = str.ToCharArray();
        string ansStr="";
        foreach (char ch in ar)
        {
            if(!char.IsLetter(ch))
                return "";
            int aCh = ch;
            if(aCh%2!=0)
                ansStr+=ch;
        }
        ansStr = new string(ansStr.Reverse().ToArray());
        char[] result = ansStr.ToCharArray();
        for (int i=0;i<result.Length;i++)
        {
            if (i % 2 == 0)
                result[i] = char.ToUpper(result[i]);
        }
        return new string(result);
    }
    public static void Main()
    {
        Console.Write("enter the string : ");
        string ans=CleanseAndInvert(Console.ReadLine());
        Console.WriteLine("Ans: "+ ans);
    }
}