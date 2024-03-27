using AssignmentBehavioral.Modals;
using AssignmentBehavioral.Modals.Enums;

namespace AssignmentBehavioral;

internal static class Program
{
    public static void Main(string[] args)
    {
        var bookList = CreateBookList();
        var userList = CreateUserList();
        
        //Creating order with book list
        var order = new Order(Guid.NewGuid(), bookList.ToList());
        
        //Subscribe users for specific order
        order.Subscribe(userList.ToList());
        
        //Notifying client users about pending order
        order.Notify();
        
        //Placing the order notifying all users
        order.PlaceOrder();
        
        //Processing the order notifying only client user
        order.ProcessingOrder();
        
        //Unsubscribe manager for receiving emails
        order.Unsubscribe(userList.ToList()[1]);
        
        //Getting ready for shipping and notifying all users
        order.GettingOrderReadyForShipping();
        
        //Deliver order and notify only client user
        order.DeliverOrder();
    }

    private static IEnumerable<Book> CreateBookList() => new List<Book>()
    {
        new(Guid.NewGuid(), "Lord of the Rings", "J.R.R. Tolkien", 100),
        new(Guid.NewGuid(), "Harry Potter", "J. K. Rowling", 50),
        new(Guid.NewGuid(), "Dune", "Frank Herbert", 400)
    };

    private static IEnumerable<ISubscriber> CreateUserList() => new List<User>()
    {
        new("will_smith@gmail.com", UserRole.CLIENT),
        new("big_boss@gmail.com", UserRole.STAFF),
        new("me_driver@gmail.com", UserRole.STAFF)
    };
}