using System.Text;

namespace DelegateSample;

class Program
{
    public  delegate int MathOp(int a, int b);
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // bài 1
        Bai1();
        // bài 2
        Bai2("Alo");
    }

    static void Bai2(string msg)
    {
        var notification = new Notifycation();
        notification.OnNotify += LogEX.LogToConsole;
        notification.OnNotify += LogEX.LogToFile;
        notification.Notify(msg);
    }
    static void Bai1()
    {
        int a = 4274;
        int b = 1587;
        
        // bài 1: khởi tạo delegate với các hàm add,sub,mul,div
        Console.WriteLine("---- bài 1:khởi tạo delegate với các hàm add,sub,mul,div -----");
        Console.WriteLine("---- a={0}, b={1} -----",a,b);
        MathOp op =  EX1.Add;
        Console.WriteLine($"=>Add: a + b={op(a,b)} ");
        op = EX1.Sub;
        Console.WriteLine($"=>Sub: a - b={op(a,b)} ");
        op = EX1.Mul;
        Console.WriteLine($"=>Mul: a * b={op(a,b)} ");
        op = EX1.Div;
        Console.WriteLine($"=>Div: a / b={op(a,b)} ");
        // thử với func
        Func<int,int,int> MathFunc = EX1.Add;
        MathFunc += EX1.Sub;
        MathFunc += EX1.Mul;
        MathFunc += EX1.Div; 
        Console.WriteLine($"-{MathFunc(a,b)}-");
    }
}