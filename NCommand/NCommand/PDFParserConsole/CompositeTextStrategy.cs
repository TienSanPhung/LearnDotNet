namespace PDFParserConsole;
using System.Collections.Generic;
    
public class CompositeTextStrategy : ITextExtractionStrategy
{
    private readonly List<ITextExtractionStrategy> _strategies = new()
    {
        new BasicTextStrategy(),
        new VietnameseTextStrategy(),
        new MathFormulaStrategy()
    };
    public string Extract(string raw)
    {
        foreach (var s in _strategies) raw = s.Extract(raw);
        return raw;
    }
}