using System.Text.RegularExpressions;

namespace PDFParserConsole;
    
public static class VietnameseTextNormalizer
{
    public static string Normalize(string input)
    {
        return Regex.Replace(input, @"\s+", " ").Trim();
    }
}