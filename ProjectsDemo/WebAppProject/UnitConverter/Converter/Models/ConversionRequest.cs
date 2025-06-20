namespace Converter.Models;

public class ConversionRequest
{
    public double Value { get; set; }
    public string FromUnit { get; set; }
    public string ToUnit { get; set; }
    public string Type { get; set; }

}