namespace PDFParserConsole;
using System.Text.RegularExpressions;
public class VietnameseTextStrategy :ITextExtractionStrategy
{
    public string Extract(string raw) => VietnameseTextNormalizer.Normalize(raw);
}