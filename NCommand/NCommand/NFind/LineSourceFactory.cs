namespace NFind;

public class LineSourceFactory
{
    public static ILineSource[] CreateInstance(string path, bool skipOfflineFile)
    {
        if (string.IsNullOrEmpty(path))
        {
            return  [new ConsoleLineSource()] ;
        }
        else
        {
            var dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                var files = dir.GetFiles();
                if (skipOfflineFile)
                {
                    files = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Offline)).ToArray();
                }
                return files.Select(f => new FileLineSource(f.FullName)).ToArray();
            }
        }
        return [];
    }
    
}