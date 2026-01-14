using System;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

public class LinqExample
{
    public LinqExample()
    {
        // var procColl= from p in System.Diagnostics.Process.GetProcesses()
        //               select new  MyProcess(){ Name=p.ProcessName, Id=p.Id};
        // foreach( var proc in procColl)
        //     Console.WriteLine($"Process name = {proc.Name}  ID = {proc.Id}");
        var procColl= from p in System.Diagnostics.Process.GetProcesses()
                      select new  { Name=p.ProcessName, Id=p.Id};
        foreach( var proc in procColl)
            Console.WriteLine($"Process name = {proc.Name}  ID = {proc.Id}");
    }
    
}

public class MyProcess
{
    public string Name { get; set; } = "";
    public int Id { get; set; }
}


public class Example
{
    public static void Main()
    {
        LinqExample obj = new LinqExample();
    }
}
