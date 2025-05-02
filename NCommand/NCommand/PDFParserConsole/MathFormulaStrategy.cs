using System.Text.RegularExpressions;
using PDFParserConsole;


public class MathFormulaStrategy :  ITextExtractionStrategy
{
    private static readonly Regex MathRegex = new(@"[0-9]+\s*[\+\-\*/=^]\s*[0-9]+|[∑∫√π∞]|\\frac\\{.*?\\}\\{.*?\\}", RegexOptions.Compiled);
    public string Extract(string raw) => MathRegex.Replace(raw, m => $"<Math:{m.Value}>");
}