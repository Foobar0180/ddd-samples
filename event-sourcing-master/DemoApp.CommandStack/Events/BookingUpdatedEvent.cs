using System;
using DemoApp.Infrastructure.Framework;
using DemoApp.SharedKernel;

namespace DemoApp.CommandStack.Events
{

    // Must have a public constructor and public SETTERS if you want to serialize it to JSON to event stores.
    public class BookingUpdatedEvent : Event
    {
        public BookingUpdatedEvent()
        { }

        public BookingUpdatedEvent(int id, int hour, string name, int length)
        {
            Id = id; 
            When = DateTime.Now;
            SagaId = id;
            Data = new SlotInfo {BookingId = id, Name = name, StartingAt = hour, Length = length};
        }

        public int Id { get; set; }
        public DateTime When { get; set; }
        public SlotInfo Data { get; set; }
    }
}