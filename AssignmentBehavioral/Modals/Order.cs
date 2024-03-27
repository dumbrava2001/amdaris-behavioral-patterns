using AssignmentBehavioral.Modals.Enums;

namespace AssignmentBehavioral.Modals;

public class Order : ISubject
{
    public Guid Id { get; set; }
    public List<Book> BookList { get; set; }
    public OrderStatus Status { get; set; }
    public double TotalPrice => BookList.Sum(b => b.Price);

    private readonly List<ISubscriber> _subscribers = new();

    public Order(Guid id, List<Book> bookList)
    {
        Id = id;
        BookList = bookList;
        Status = OrderStatus.PENDING;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Subscribe(List<ISubscriber> subscribers)
    {
        _subscribers.AddRange(subscribers);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        Console.WriteLine("Notifying all subscribers");
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(this);
        }
    }

    public void PlaceOrder()
    {
        Console.WriteLine($"Placing order {Id} on {DateTime.Now}");
        Status = OrderStatus.PLACED;
        Notify();
    }

    public void ProcessingOrder()
    {
        Console.WriteLine($"Processing order: {Id} on {DateTime.Now}");
        Status = OrderStatus.PROCESSING;
        Notify();
    }

    public void GettingOrderReadyForShipping()
    {
        Console.WriteLine($"Getting ready order {Id} for shipping on {DateTime.Now}");
        Status = OrderStatus.READY_FOR_SHIPPING;
        Notify();
    }

    public void DeliverOrder()
    {
        Console.WriteLine($"Deliver order {Id} on {DateTime.Now}");
        Status = OrderStatus.DELIVERED;
        Notify();
    }
}