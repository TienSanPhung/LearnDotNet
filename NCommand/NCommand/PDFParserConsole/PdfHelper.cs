namespace PDFParserConsole;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class PdfHelper
{
    public static Dictionary<string, string> ParseDictionary(string txt)
    {
        var dict = new Dictionary<string, string>();
        var matches = Regex.Matches(txt, @"/(?<key>\w+)\s+(?<val>\S+)");
        foreach (Match m in matches) dict[m.Groups["key"].Value] = m.Groups["val"].Value;
        return dict;
    }

    public static byte[] ReadStreamData(Stream s, int length, string filter)
    {
        byte[] buf = new byte[length];
        s.Read(buf, 0, length);
        return filter switch
        {
            "/FlateDecode" => DecompressFlate(buf),
            "/ASCIIHexDecode" => DecodeHex(buf),
            "/ASCII85Decode" => DecodeASCII85(buf),
            _ => buf
        };
    }

    private static byte[] DecompressFlate(byte[] data)
    {
        using var ms = new MemoryStream(data, 2, data.Length - 2);
        using var ds = new DeflateStream(ms, CompressionMode.Decompress);
        using var outMs = new MemoryStream();
        ds.CopyTo(outMs);
        return outMs.ToArray();
    }

    private static byte[] DecodeHex(byte[] data)
    {
        var hex = Encoding.ASCII.GetString(data).Trim();
        var ms = new MemoryStream();
        for (int i = 0; i < hex.Length; i += 2) ms.WriteByte(Convert.ToByte(hex.Substring(i, 2), 16));
        return ms.ToArray();
    }

    private static byte[] DecodeASCII85(byte[] data)
    {
        string str = Encoding.ASCII.GetString(data).Trim('<', '~', '>');
        var output = new List<byte>();
        for (int i = 0; i < str.Length; i += 5)
        {
            ulong tuple = 0;
            int chunkLen = Math.Min(5, str.Length - i);
            for (int j = 0; j < chunkLen; j++) tuple = tuple * 85 + (uint)(str[i + j] - '!');
            for (int j = 3; j >= 0; j--) output.Add((byte)((tuple >> (8 * j)) & 0xFF));
        }

        return output.ToArray();
    }
}