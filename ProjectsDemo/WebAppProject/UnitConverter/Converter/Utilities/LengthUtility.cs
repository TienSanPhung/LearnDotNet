namespace Converter.Utilities;

public class LengthUtility
{
    public static readonly Dictionary<string, double> LengthFactors = new()
    {
        {"mm",1},
        {"cm",10},
        {"m",1000},
        {"km",1000000},
        {"ft",304.8},
        {"yd",914.4},
        {"mi",1609344},
        {"inch",25.4}
    };
    public double Convert(double value, string from, string to)
    {
        if (!LengthFactors.ContainsKey(from) && !LengthFactors.ContainsKey(to))
        {
            throw new ArgumentNullException("Đơn vị không hợp lệ.");
        }
        var d = value * LengthFactors[from] / LengthFactors[to];
        return d;
    }
}

