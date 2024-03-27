namespace AssignmentBehavioral.Modals;

public interface ISubject
{
    void Subscribe(ISubscriber subscriber);
    void Subscribe(List<ISubscriber> subscribers);
    
    void Unsubscribe(ISubscriber subscriber);
    void Notify();
}