using System.Runtime.InteropServices;
using ReadAndWriteFile.Bai1;

namespace ReadAndWriteFile;

class Program
{
    static void Main(string[] args)
    { 
        var bai1 = new ReadWritebyStreamWriteReader(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\ReadAndWriteFile\Bai1\NewFile.txt");
        Print(bai1.ReadAndWrite());
       
    }

    static void Print(List<string> readAndWrite)
    {
        foreach (var s in readAndWrite)
        {
            Console.WriteLine(s);
        }
    }
}