using System;
using System.Collections;
public class BigBoy: IDisposable
{
    public BigBoy()
    {
        
    }
    public ArrayList Names {get; set;}
    public void Dispose()
    {
        Names = null;
    }
    
}
public class Program
{
    static void main()
    {
        BigBoy bigb = new BigBoy();
        try
        {
            bigb Names =new System.Collections.ArrayList();
            for(int i=0;i<10;i++)
            {
                bigb.Names.Add(i.ToString());
            }
        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            bigb.Dispose;
        }
    }
}