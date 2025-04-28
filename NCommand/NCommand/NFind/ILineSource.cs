namespace NFind;

public interface ILineSource
{
    Line? ReadLine();
    void Open();
    void Close();
}