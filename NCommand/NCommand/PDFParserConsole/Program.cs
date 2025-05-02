namespace PDFParserConsole;

class Program
{
    static void Main(string[] args)
    {
        string filePath;
        if (args.Length == 0)
        {
            Console.Write("Nhập đường dẫn tới file PDF hoặc DOCX: ");
            filePath = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Không có đường dẫn hợp lệ. Thoát chương trình.");
                return;
            }
        }
        else
        {
            filePath = args[0];
        }

        // Cho phép test template method nếu nhập "test"
        /*if (filePath.Equals("test", StringComparison.OrdinalIgnoreCase))
        {
            var testParser = new TestParser();
            testParser.Parse("dummy.pdf");
            return;
        }*/

        try
        {
            var parser = ParserFactory.Create(filePath);
            parser.Parse(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
