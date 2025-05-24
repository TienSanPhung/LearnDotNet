using TaskCLI.Repository;
using TaskCLI.Repository.JsonFileRepository;

namespace TaskCLI.Factory;

public class TaskCLIFactory 
{
    public static ITaskRepository CreateInstance(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Path is empty, use Database");
            // logic sử dụng database
            return null;
        }
        else
        {
            if (File.Exists(path))
            {
                return new JsonTaskRepository(path);
            }
            Console.WriteLine("Path is not exist");
            return null;
        }
        
    }
    
}