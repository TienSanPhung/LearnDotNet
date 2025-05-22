// ReSharper disable All
namespace AttributeSample;

class Program
{
    
    static void Main(string[] args)
    {
        var dbMethodAttr = (DbMethodAttribute)Attribute.GetCustomAttribute(typeof(Nnnn).GetMethod("PrintHello1"), typeof(DbMethodAttribute));
        Console.WriteLine(dbMethodAttr.Message);
        dbMethodAttr = (DbMethodAttribute)Attribute.GetCustomAttribute(typeof(Nnnn).GetMethod("PrintHello2"), typeof(DbMethodAttribute));
        Console.WriteLine(dbMethodAttr.Message);
            
    }
    
    
}