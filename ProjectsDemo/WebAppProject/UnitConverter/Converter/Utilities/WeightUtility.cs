namespace Converter.Utilities;

public class WeightUtility
{
    public static  Dictionary<string,double> WeightFactors = new()
    {
        { "mg", 0.001 },
        { "g", 1 },
        { "kg", 1000 },
        { "ton", 1_000_000 },
        { "oz", 28.3495 },
        { "lb", 453.592 }
    };

    public double Convert(double value, string from, string to)
    {
        if (!WeightFactors.ContainsKey(from) && !WeightFactors.ContainsKey(to))
        {
            throw new ArgumentNullException("đơn vị không hợp lệ");
        }
        var d = value * WeightFactors[from] / WeightFactors[to];
        return d;
    }
}