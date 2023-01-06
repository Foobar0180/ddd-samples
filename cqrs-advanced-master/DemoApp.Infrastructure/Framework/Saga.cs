using System;
using DemoApp.Infrastructure.Framework.EventStore;

namespace DemoApp.Infrastructure.Framework
{
    public abstract class Saga
    {
        public IBus Bus { get; private set; }
        public IEventStore EventStore { get; private set; }


        protected Saga(IBus bus, IEventStore eventStore)
        {
             Bus = bus ?? throw new ArgumentNullException(nameof(bus));
            EventStore = eventStore;
        }
    }

}