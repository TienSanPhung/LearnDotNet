using System.IO.Packaging;
using System.Text;
using System.Xml;

namespace PDFParserConsole;

public class DocxParser : DocumentParser
{
    private readonly StringBuilder _text = new();
    protected override void Open(string path) { }
    protected override void ReadHeader() { }
    protected override void ReadXrefAndTrailer() { }
    protected override void ParseBody()
    {
        using var pkg = Package.Open(FilePath, FileMode.Open, FileAccess.Read);
        var part = pkg.GetPart(new Uri("/word/document.xml", UriKind.Relative));
        using var xml = XmlReader.Create(part.GetStream());
        while (xml.Read()) if (xml.NodeType == XmlNodeType.Text) _text.Append(xml.Value);
    }
    protected override string ExtractText() => _text.ToString();
}