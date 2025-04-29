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
        if (fileOptions.HelpMode)
        {
            Console.WriteLine(@"Searches for a text string in a file or files.

FIND [/V] [/C] [/N] [/I] [/OFF[LINE]] ""string"" [[drive:][path]filename[ ...]]

  /V         Displays all lines NOT containing the specified string.
  /C         Displays only the count of lines containing the string.
  /N         Displays line numbers with the displayed lines.
  /I         Ignores the case of characters when searching for the string.
  /OFF[LINE] Do not skip files with offline attribute set.
  ""string""   Specifies the text string to find.
  [drive:][path]filename
             Specifies a file or files to search.

If a path is not specified, FIND searches the text typed at the prompt
or piped from another command.");
        }
        var sources = LineSourceFactory.CreateInstance(fileOptions.Path,fileOptions.SkipOfflineFile);
        foreach (var source in sources)
        {
            ProcessSource(source, fileOptions);
        }
    }

    private static void ProcessSource(ILineSource source, FileOptions fileOptions)
    {
        var stringComparison = fileOptions.IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
        source = new FilterLineSource(source, 
            (line)=> fileOptions.FindDontConstain ? !line.Text.Contains(fileOptions.StringToFind, stringComparison) : line.Text.Contains(fileOptions.StringToFind,stringComparison));
        Console.WriteLine($"-------- {source.Name.ToUpper()} --------");
        try
        {
            source.Open();
            var line = source.ReadLine();
            while (line != null)
            {
                PrintLine(line, fileOptions.ShowLineNumeber);
                line = source.ReadLine();
            }
        }
        finally
        {
            source.Close();
        }
    }

    private static void PrintLine(Line line, bool showLineNumeber)
    {
        if (showLineNumeber)
        {
            Console.WriteLine($"[{line.LineNumber}] {line.Text}]");
        }
        else
        {
            Console.WriteLine($"{line.Text}]");
        }
        
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


