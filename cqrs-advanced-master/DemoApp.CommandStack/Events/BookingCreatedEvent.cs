﻿using System;
using DemoApp.Infrastructure.Framework;

namespace DemoApp.CommandStack.Events
{
    public class BookingCreatedEvent : Event
    {
        public BookingCreatedEvent(Guid requestId, int id)
        {
            RequestId = requestId;
            Id = id; 
            When = DateTime.Now;
        }

        public int Id { get; private set; }
        public Guid RequestId { get; private set; }
        public DateTime When { get; private set; }
    }
}