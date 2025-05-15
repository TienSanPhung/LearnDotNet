namespace OOPSample;

public class Book
{
    private  string Title ;
    private string Author  ;
    private  string ISBN; 
    private bool IsBorrowed  = false;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
    
    public void Borrow(){if(!IsBorrowed){IsBorrowed = true;}}
    public void Return(){if(IsBorrowed){IsBorrowed = false;}}
    public override string ToString(){return $"{Title} by {Author} (ISBN: {ISBN})"+"---" + (IsBorrowed ? " [Đã mượn]" : " ");}
    
}