using System;
using DemoApp.Infrastructure.Framework;
using DemoApp.SharedKernel;

namespace DemoApp.CommandStack.Events
{
    public class BookingCreatedEvent : Event
    {
        public BookingCreatedEvent()
        { }

        public BookingCreatedEvent(Guid requestId, int id, SlotInfo slotInfo)
        {
            RequestId = requestId;
            Id = id;
            When = DateTime.Now;
            Data = slotInfo;
            SagaId = id;
        }

        public int Id { get; set; }
        public Guid RequestId { get; set; }
        public DateTime When { get; set; }
        public SlotInfo Data { get; set; }
    }
}