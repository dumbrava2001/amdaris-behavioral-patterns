using AssignmentBehavioral.Modals.Enums;

namespace AssignmentBehavioral.Modals;

public class User : ISubscriber
{
    public string Email { get; set; }
    public UserRole UserRole { get; init; }

    public User(string email, UserRole userRole)
    {
        Email = email;
        UserRole = userRole;
    }

    public void Update(ISubject subject)
    {
        var order = (Order)subject;
        if (UserRole == UserRole.STAFF &&
            order.Status != OrderStatus.PLACED &&
            order.Status != OrderStatus.READY_FOR_SHIPPING) return;

        Console.WriteLine($"Sending email to {Email}");
        Console.WriteLine($"Order:{order.Id} is {order.Status}");
        Console.WriteLine("Email delivered...\n");
    }
}