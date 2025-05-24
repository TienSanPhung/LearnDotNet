using System.Runtime.InteropServices;
using System.Text;
using TaskCLI.Repository;
using TaskCLI.Factory;

namespace TaskCLI;

class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: TaskCLI <command> Paramater");
            return ;
        }
        string path = @"C:\Users\pts20\Desktop\.net\LearnDotNet\ProjectsDemo\RoadMapProject\TaskCLI\DataJson\TaskItem.json";
        ITaskRepository repository = TaskCLIFactory.CreateInstance(path);
        ProcessOption(repository,args);
    }

    static void ProcessOption(ITaskRepository repository, string[] args)
    {
        string command = args[0];
        string[] param = args.Skip(1).ToArray();

        if (command == "add" )
        {
            if (param.Length == 1)
            {
                AddTask(repository, param[0]);
            }
            else
            {
                Console.WriteLine("Add task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <Add> \"Task description\"");
            }
            
        }
        else if(command == "update")
        {
            if (param.Length == 2)
            {
                UpdateTask(repository, param[0], param[1]);
                Console.WriteLine("Update task success");
            }
            else
            {
                Console.WriteLine("Add task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <update> id \"Task description\"");
            }
        }else if(command == "delete")
        {
            if (param.Length == 1)
            {
                DeleteTask(repository, param[0]);
                Console.WriteLine("Delete task success");
            }
            else
            {
                Console.WriteLine("Add task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <delete> id ");
            }
        }else if(command == "mark-in-progress")
        {
            if (param.Length == 1)
            {
                MarkTask(repository, param[0], "in-progress");
                Console.WriteLine("Task is in progress");
            }
            else
            {
                Console.WriteLine("Add task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <mark-in-progress> id ");
            }
        }else if(command == "mark-done")
        {
            if (param.Length == 1)
            {
                MarkTask(repository, param[0], "done");
                Console.WriteLine("Task is done");
            }
            else
            {
                Console.WriteLine("Add task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <mark-done> id ");
            }
        }else if(command == "list")
        {
            if (param.Length == 0 )
            {
                var task = repository.List();
                PrintTask(task);
            }
            else if (param.Length == 1)
            {
                ListTask(repository, param);
            }
            else
            {
                Console.WriteLine("List task fail: check your paramater");
                Console.WriteLine("Usage: TaskCLI <list> Paramater(done, in-progress,todo)");
            }
        }
        else
        {
            Console.WriteLine("Usage: TaskCLI <command> Paramater");
            
        }
    }

    static void ListTask(ITaskRepository repository, string[] args)
    {
        if (args[0] == "done" )
        {
            var task = repository.ListWithStatus(TaskStatus.Done);
            PrintTask(task);
        }else if (args[0] == "in-progress" )
        {
            var task = repository.ListWithStatus(TaskStatus.InProgress);
            PrintTask(task);
        }else if (args[0] == "todo" )
        {
            var task = repository.ListWithStatus(TaskStatus.ToDo);
            PrintTask(task);
        }
    }

    static void PrintTask(List<TaskItems> task)
    {
        Console.WriteLine("------------- TASK ---------------");
        Console.WriteLine($"{"ID",-5} {"Description",-30} {"Status",-15} {"CreatedDate",-30} {"UpdatedDate",-20}");
        Console.WriteLine();
        foreach (var item in task)
        {
            Console.WriteLine($"{item.Id,-5} {item.Description,-30} {item.Status,-15} {item.CreatedDate,-30} {item.UpdatedDate,-20}");
        }
    }

    static void MarkTask(ITaskRepository repository, string id, string status)
    {
        int i = int.Parse(id);
        TaskItems taskItem = new TaskItems()
        {
            Id = i,
            Description = String.Empty,
            UpdatedDate = DateTime.Now,
        };
        if (status == "in-progress")
        {
            taskItem.Status = TaskStatus.InProgress;
           
        }
        else if(status == "done")
        {
            taskItem.Status = TaskStatus.Done;
            
        }
        
        repository.Update(taskItem);
    }

    static void DeleteTask(ITaskRepository repository, string s)
    {
       int i = int.Parse(s);
        repository.Delete(i);
    }

    static void UpdateTask(ITaskRepository repository, string id, string s)
    {
        int i = int.Parse(id);
        string description = s;
        TaskItems taskItem = new TaskItems
        {
            Id = i,
            Description = description
        };
        repository.Update(taskItem);
    }

    static void AddTask(ITaskRepository repository, string s)
    {
        TaskItems taskItem = new TaskItems
        {
            Description = s,
            CreatedDate = DateTime.Now
        };
        repository.Add(taskItem);
        Console.WriteLine("Add task success");
    }
}