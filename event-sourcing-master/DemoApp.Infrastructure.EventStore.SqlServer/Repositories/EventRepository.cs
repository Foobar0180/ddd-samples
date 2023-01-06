using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Infrastructure.EventStore.SqlServer.Data;

namespace DemoApp.Infrastructure.EventStore.SqlServer.Repositories
{
    public class EventRepository
    {
        private readonly DemoAppEventStore _db = new DemoAppEventStore();

        public void Store(LoggedEvent eventToLog)
        {
            eventToLog.TimeStamp = DateTime.Now;
            _db.LoggedEvents.Add(eventToLog);
            _db.SaveChanges();
        }

        public IList<LoggedEvent> All(int aggregateId)
        {
            var events = (from e in _db.LoggedEvents where e.AggregateId == aggregateId select e).ToList();
            return events;
        }
    }
}