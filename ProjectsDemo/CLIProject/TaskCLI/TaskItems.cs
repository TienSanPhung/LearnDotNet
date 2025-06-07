using System.Runtime.InteropServices.JavaScript;

namespace TaskCLI;

public class TaskItems
{
    public  int Id {get;set;} = 0;
    public required string Description {get;set;} = String.Empty;
    public TaskStatus Status {get;set;} = TaskStatus.ToDo;
    public DateTime CreatedDate {get;set;} = DateTime.Now;
    public DateTime UpdatedDate {get;set;} = DateTime.Now;
}