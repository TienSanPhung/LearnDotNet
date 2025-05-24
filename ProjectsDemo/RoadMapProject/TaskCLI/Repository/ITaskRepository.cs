namespace TaskCLI.Repository;

public interface ITaskRepository
{
    TaskItems Add(TaskItems taskItem);
    TaskItems GetById(int id);
    List<TaskItems> List();
    List<TaskItems> ListWithStatus(TaskStatus status);
    void Update(TaskItems taskItem);
    void Delete(int id);
    
    
}