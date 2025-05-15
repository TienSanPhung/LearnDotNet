namespace OOPSample;

public class User
{
    private int Id;
    protected string Name ;

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public virtual void ViewBooks(List<Book> books)
    {
        Console.WriteLine($"User {Name} đang xem danh sách");
        foreach (var book in books)
        {
            Console.WriteLine(book.ToString());
        }
    }
    
}