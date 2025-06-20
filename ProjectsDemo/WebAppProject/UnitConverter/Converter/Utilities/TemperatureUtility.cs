namespace Converter.Utilities;

public class TemperatureUtility
{
    public double Convert(double value, string from, string to)
    {
        if (from == to)
        {
            return value;
        }
        var d = from switch
        {
            "c" => value,
            "k" => value - 273.15,
            "f" => (value - 32 ) * 5 /9,
            _ => throw new ArgumentNullException("đơn vị không chính xác.")
        };
        return to switch
        {
            "c" => value,
            "k" => value + 273.15,
            "f" => (value * 9 / 5 ) + 32,
            _ => throw new ArgumentNullException("đơn vị không chính xác.")
        };
    }
}