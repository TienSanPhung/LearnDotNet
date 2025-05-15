namespace OOPSample;

public class Librarian : User
{
    public Librarian(int id, string name) : base(id, name)
    {
        
    }

    public override void ViewBooks(List<Book> books)
    {
        Console.WriteLine($"[Thủ thư] {Name} đang quản lý {books.Count} sách");
        books.ForEach(b => Console.WriteLine($"  • {b}"));
    }

    public void AddBook(List<Book> books, Book book)
    {
        books.Add(book);
        Console.WriteLine($"Đã thêm {book}");
    }
    public void RemoveBook(List<Book> books, Book book)
    {
        books.Remove(book);
        Console.WriteLine($"Đã xóa {book}");
    }
}