using System.Text.Json;

namespace TaskCLI.Repository.JsonFileRepository;

public class JsonTaskRepository : ITaskRepository
{
    readonly string _path;
    private List<TaskItems> _taskItems = new() ;
    public JsonTaskRepository(string path)
    {
        this._path = path;
        LoadTask(path);
    }

    void LoadTask(string path)
    {
        if (File.Exists(path))
        {
            try
            {
                string json = File.ReadAllText(path);
                if (String.IsNullOrEmpty(json))
                {
                    _taskItems = new List<TaskItems>();
                }
                else
                {
                    _taskItems = JsonSerializer.Deserialize<List<TaskItems>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading Json file: "+ex.Message);
                _taskItems = new List<TaskItems>();
            }
        }
        else
        {
            _taskItems = new List<TaskItems>();
            SaveChanges();
        }
    }

    void SaveChanges()
    {
        try
        {
            var option = new JsonSerializerOptions{WriteIndented = true};
            string json = JsonSerializer.Serialize(_taskItems, option);
            File.WriteAllText(_path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing JSON file: " + ex.Message);
        }
    }

    public TaskItems Add(TaskItems taskItem)
    {
        taskItem.Id = (_taskItems.Count == 0) ? 1 : _taskItems[_taskItems.Count - 1].Id + 1;
        _taskItems.Add(taskItem);
        SaveChanges();
        return taskItem;
    }

    public TaskItems GetById(int id)
    {
        return _taskItems.FirstOrDefault(x => x.Id == id);
    }

    public List<TaskItems> List()
    {
        return _taskItems;
    }

    public List<TaskItems> ListWithStatus(TaskStatus status)
    {
        return _taskItems.Where(x => x.Status == status).ToList();
    }

    public void Update(TaskItems taskItem)
    {
        var item = _taskItems.FirstOrDefault(x => x.Id == taskItem.Id);
        if (item != null)
        {
            item.Status = taskItem.Status;
            item.UpdatedDate = DateTime.Now;
            SaveChanges();
        }
    }

    public void Delete(int id)
    {
        _taskItems.RemoveAll(x => x.Id == id);
        SaveChanges();
    }
}