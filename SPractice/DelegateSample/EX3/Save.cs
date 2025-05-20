namespace DelegateSample.EX3;

public class Save
{
    public static void SavePlugin(string data)
    {
        File.AppendAllText(@"C:\Users\pts20\Desktop\.net\LearnDotNet\SPractice\DelegateSample\EX3\dataPlugin.txt", data);
        Console.WriteLine($"[SAVE] Đã lưu vào dataPlugin.txt");
    }
}