using System;
using System.Collections.Generic;

namespace DemoApp.CommandStack.Domain.Common
{
    public interface IAggregate
    {
        Guid Id { get; }
        bool HasPendingChanges { get; }
        IEnumerable<DomainEvent> GetUncommittedEvents();
        void ClearUncommittedEvents(); 
    }
}