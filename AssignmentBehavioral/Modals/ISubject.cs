namespace AssignmentBehavioral.Modals;

public interface ISubject
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Notify();
}