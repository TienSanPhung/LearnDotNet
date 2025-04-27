namespace NFind;

public class FileOptions
{
    public string  StringToFind { get; set; } = string.Empty;
    public bool IsCaseSensitive { get; set; } = true;
    public bool FindDontConstain { get; set; } = false;
    public bool CountMode { get; set; } = false;
    public bool ShowLineNumeber { get; set; } = false;
    public bool  SkipOfflineFile { get; set; } = true;
    public string Path { get; set; } = string.Empty;
    public bool HelpMode { get; set; } = false;
}