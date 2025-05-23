using System.Runtime.InteropServices;
using System.Text;
using ReadAndWriteFile.Bai1;
using ReadAndWriteFile.Bai2;
using ReadAndWriteFile.Bai3;
using ReadAndWriteFile.Bai4;

namespace ReadAndWriteFile;

class Program
{
    static void Main(string[] args)
    { 
        Console.OutputEncoding = Encoding.UTF8;
        var bai1 = new ReadWritebyStreamWriteReader(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\ReadAndWriteFile\Bai1\NewFile.txt");
        Print(bai1.ReadAndWrite());
        var bai2 = new ReadWriteByFileStream(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\ReadAndWriteFile\Bai2\NewFile.txt");
        bai2.ReadAndWrite();
        var bai3 = new ReadWriteByBufferedStream(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\ReadAndWriteFile\Bai3\NewFile.txt");
        bai3.ReadAndWrite();
        var bai4 = new ReadWriteByFileSeek(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\ReadAndWriteFile\Bai4\NewFile.txt");
        bai4.ReadAndWrite();
    }

    static void Print(List<string> readAndWrite)
    {
        Console.WriteLine($"-------------bài 1---------------");
        foreach (var s in readAndWrite)
        {
            Console.WriteLine(s);
        }
    }
}