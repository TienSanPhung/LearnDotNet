namespace PDFParserConsole;

public static class ParserFactory
{
    public static DocumentParser Create(string fileName)
    {
        var ext = System.IO.Path.GetExtension(fileName).ToLower();
        return ext switch
        {
            ".pdf" => new PdfParser(),
            ".docx" => new DocxParser(),
            _ => throw new NotSupportedException($"Unsupported format: {ext}"),
        };
    }
}
