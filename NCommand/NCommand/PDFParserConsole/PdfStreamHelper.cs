namespace PDFParserConsole;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
public static class PdfStreamHelper
{
     public static void ParseXref(Stream stream, Dictionary<int, long> xrefTable)
        {
            stream.Seek(-2048, SeekOrigin.End);
            var tail = ReadString(stream, 2048);
            var idx = tail.LastIndexOf("startxref");
            var offset = long.Parse(tail.Substring(idx).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            stream.Seek(offset, SeekOrigin.Begin);
            if (ReadLine(stream) != "xref") throw new Exception("xref not found.");
            while (true)
            {
                var line = ReadLine(stream);
                if (line.StartsWith("trailer")) break;
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int start = int.Parse(parts[0]), count = int.Parse(parts[1]);
                for (int i = 0; i < count; i++)
                {
                    var entry = ReadLine(stream);
                    var off = long.Parse(entry.Substring(0, 10));
                    xrefTable[start + i] = off;
                }
            }
        }

        public static void ExtractRawStreams(Stream stream, Dictionary<int, long> xrefTable, List<byte> buffer)
        {
            foreach (var kvp in xrefTable)
            {
                stream.Seek(kvp.Value, SeekOrigin.Begin);
                var header = ReadLine(stream);
                if (!header.EndsWith("obj")) continue;
                var dictText = ReadUntil(stream, ">>");
                var dict = PdfHelper.ParseDictionary(dictText);
                if (dict.ContainsKey("Length"))
                {
                    int len = int.Parse(dict["Length"]);
                    string filter = dict.ContainsKey("Filter") ? dict["Filter"] : null;
                    var data = PdfHelper.ReadStreamData(stream, len, filter);
                    buffer.AddRange(data);
                }
            }
        }

        public static string ReadLine(Stream s)
        {
            var sb = new StringBuilder();
            int b;
            while ((b = s.ReadByte()) != -1 && b != '\n')
                if (b != '\r') sb.Append((char)b);
            return sb.ToString();
        }
        public static string ReadString(Stream s, int length)
        {
            var buf = new byte[length];
            s.Read(buf, 0, length);
            return Encoding.ASCII.GetString(buf);
        }
        public static string ReadUntil(Stream s, string term)
        {
            var sb = new StringBuilder();
            var t = Encoding.ASCII.GetBytes(term);
            var window = new Queue<byte>();
            int b;
            while ((b = s.ReadByte()) != -1)
            {
                sb.Append((char)b);
                window.Enqueue((byte)b);
                if (window.Count > t.Length) window.Dequeue();
                if (window.Count == t.Length && window.ToArray().AsSpan().SequenceEqual(t)) break;
            }
            return sb.ToString();
        }
}