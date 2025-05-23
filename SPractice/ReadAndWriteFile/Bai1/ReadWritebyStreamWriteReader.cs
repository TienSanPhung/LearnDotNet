namespace ReadAndWriteFile.Bai1;

public class ReadWritebyStreamWriteReader
{
    readonly string filePath;

    public ReadWritebyStreamWriteReader(string _filePath)
    {
        this.filePath = _filePath;
    }
    public List<string> ReadAndWrite()
    {
        List<string> Lines = new();
        using (var writer = new StreamWriter(filePath)){
            writer.WriteLine("Creates an ILoggerFactory.");
            writer.WriteLine("The ILoggerFactory stores all the configuration that determines where log messages are sent.");
            writer.WriteLine("In this case, you configure the console logging provider so that log messages are written to the console.");
            writer.WriteLine("Creates an ILogger with a category named \"Program\".");
            writer.WriteLine(" The category is a string that is associated with each message logged by the ILogger object.");
            
        }

        using (var reader = new StreamReader(filePath))
        {
            string line;
            do
            {
                line = reader.ReadLine();
                if (line != null) Lines.Add(line);
            }
            while (line != null);
        }
        return Lines;
    }
}