using AssignmentBehavioral.Modals.Enums;

namespace AssignmentBehavioral.Modals;

public class Order : ISubject
{
    public Guid Id { get; set; }
    public Book Book { get; set; }
    public OrderStatus Status { get; set; }
    
    private readonly List<ISubscriber> _subscribers = new();


    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
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
}