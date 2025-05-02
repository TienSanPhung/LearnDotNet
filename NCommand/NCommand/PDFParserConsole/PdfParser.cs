namespace PDFParserConsole;
using System.IO;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
    public class PdfParser : DocumentParser
    {
        private FileStream _stream;
        private readonly Dictionary<int, long> _xrefTable = new();
        private readonly List<byte> _rawBytes = new();
        private readonly ITextExtractionStrategy _strategy = new CompositeTextStrategy();

        protected override void Open(string path) => _stream = new FileStream(path, FileMode.Open, FileAccess.Read);

        protected override void ReadHeader()
        {
            _stream.Seek(0, SeekOrigin.Begin);
            var header = PdfStreamHelper.ReadLine(_stream);
            if (!header.StartsWith("%PDF-")) throw new InvalidDataException("Not a valid PDF file.");
        }

        protected override void ReadXrefAndTrailer() => PdfStreamHelper.ParseXref(_stream, _xrefTable);

        protected override void ParseBody() => PdfStreamHelper.ExtractRawStreams(_stream, _xrefTable, _rawBytes);

        protected override string ExtractText()
        {
            var raw = System.Text.Encoding.UTF8.GetString(_rawBytes.ToArray());
            return _strategy.Extract(raw);
        }
    }
