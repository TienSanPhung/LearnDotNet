namespace PDFParserConsole;

public interface ITextExtractionStrategy
{
    string Extract(string rawContent);
}