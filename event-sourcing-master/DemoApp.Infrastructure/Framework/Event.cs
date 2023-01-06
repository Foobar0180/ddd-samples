using System;

namespace DemoApp.Infrastructure.Framework
{
    public class Event : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
            Name = GetType().Name;
        }
    }
}