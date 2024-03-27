namespace AssignmentBehavioral.Modals;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    
    public double Price { get; set; }

    public Book(Guid id, string title, string authorName, double price)
    {
        Id = id;
        Title = title;
        AuthorName = authorName;
        Price = price;
    }
}