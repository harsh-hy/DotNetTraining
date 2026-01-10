using System.Reflection;

namespace reflect
{
    static void Main()
    {
        Department dept = new Department();
        var props = dept.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        foreach (var prop in props)
        {
            Console.WriteLine(prop.Name);
        }
    }
}