namespace DelegateSample;

public class LogEX
{
    public static void LogToConsole(string msg) => Console.WriteLine($"-> log: {msg}");
    public static void LogToFile (string msg)
    {
        // Xác định đường dẫn file dựa trên thư mục project
       
        string filePath = "C:\\Users\\pts20\\Desktop\\.net\\LearnDotNet\\SPractice\\DelegateSample\\EX2\\log.txt";
        
        // Đảm bảo thư mục tồn tại trước khi ghi file
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        // Ghi dữ liệu vào file mà không ghi đè nội dung cũ
        File.AppendAllText(filePath, msg + Environment.NewLine);

        Console.WriteLine("Đã ghi log vào log.txt thành công!");
    }
}