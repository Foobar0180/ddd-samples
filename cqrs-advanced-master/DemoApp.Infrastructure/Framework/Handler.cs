using DemoApp.Infrastructure.Framework.EventStore;

namespace DemoApp.Infrastructure.Framework
{
    public abstract class Handler
    {
        public IEventStore EventStore { get; private set; }

        public Handler(IEventStore eventStore)
        {
            EventStore = eventStore;
        }
    }
}