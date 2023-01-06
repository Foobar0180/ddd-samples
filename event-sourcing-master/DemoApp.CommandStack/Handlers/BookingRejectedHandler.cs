using DemoApp.CommandStack.Events;
using DemoApp.Infrastructure.Framework;
using DemoApp.Infrastructure.Framework.EventStore;

namespace DemoApp.CommandStack.Handlers
{
    public class BookingRejectedHandler : Handler,
        IHandleMessage<BookingRequestRejectedEvent>
    {
        public BookingRejectedHandler(IEventStore eventStore) 
            : base(eventStore)
        { }

        public void Handle(BookingRequestRejectedEvent message)
        {
            throw new System.NotImplementedException();
        }
    }
}