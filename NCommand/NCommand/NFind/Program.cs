using System.Runtime.InteropServices;

namespace NFind;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("FIND: Parameter format not correct");
            return;
        }
        var fileOptions =  BuildOptions(args);
        var sources = LineSourceFactory.CreateInstance(fileOptions.Path,fileOptions.SkipOfflineFile);
        foreach (var source in sources)
        {
            ProcessSource(source);
        }
    }

    private static void ProcessSource(ILineSource source)
    {
        var line = source.ReadLine();
        while (line != null)
        {
            PrintLine(line);
            line = source.ReadLine();
        }
    }

    private static void PrintLine(Line line)
    {
        Console.WriteLine(line.Text);
    }

    public static FileOptions BuildOptions(string[] args) 
    {
        var options = new FileOptions();
        foreach (var arg in args)
        {
            if (arg == "/v")
            {
                options.FindDontConstain = true;
            }else if (arg == "/c")
            {
                options.CountMode = true;
            }else if (arg == "/i")
            {
                options.IsCaseSensitive = false;
            }else if (arg == "/n")
            {
                options.ShowLineNumeber = true;
            }else if (arg == "/off" || arg == "/offline")
            {
                options.SkipOfflineFile = false;
            }else if (arg == "/?")
            {
                options.HelpMode = true;
            }
            else
            {
                if (string.IsNullOrEmpty(options.StringToFind))
                {
                    options.StringToFind = arg;
                }
                else if (string.IsNullOrEmpty(options.Path))
                {
                    options.Path = arg;
                }
                else
                {
                    throw new ArgumentNullException(arg);
                }
                
            }
        }
        return options;
    }
}


