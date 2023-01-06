using DemoApp.CommandStack.Events;
using DemoApp.Infrastructure.Extras;
using DemoApp.Infrastructure.Framework;
using DemoApp.Infrastructure.Framework.EventStore;

namespace DemoApp.CommandStack.Handlers
{
    public class EmailHandler : Handler,
        IHandleMessage<BookingRequestRejectedEvent>,
        IHandleMessage<BookingCreatedEvent> 
    {
        public EmailHandler(IEventStore eventStore) 
            : base(eventStore)
        { }

        public void Handle(BookingRequestRejectedEvent message)
        {
            var body = $"Your request {message.RequestId} could not be satisfied.";
            EmailService.Send("user@company.com", body);
        }

        public void Handle(BookingCreatedEvent message)
        {
            var body = $"Congratulations! Your booking is confirmed. Your confirmation number is {message.Id}.";
            EmailService.Send("user@company.com", body);
        }
    }
}