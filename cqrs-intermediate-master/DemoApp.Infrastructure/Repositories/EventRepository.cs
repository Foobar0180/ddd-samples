using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Infrastructure.Data;

namespace DemoApp.Infrastructure.Repositories
{
    public class EventRepository
    {
        private readonly DemoAppEntities _database = new DemoAppEntities();

        public void Store(MatchEvent eventData)
        {
            eventData.TimeStamp = DateTime.Now;
            _database.MatchEvents.Add(eventData);
            _database.SaveChanges();
        }

        public void RemoveMostRecent(string matchId)
        {
            var last = (from e in _database.MatchEvents
                where e.MatchId == matchId
                orderby e.Id descending 
                select e).FirstOrDefault();

            if (last == null)
                return;

            _database.MatchEvents.Remove(last);
            _database.SaveChanges();
        }

        public IList<MatchEvent> All(string matchId)
        {
            var events = (from e in _database.MatchEvents 
                          where e.MatchId == matchId 
                          select e).ToList();
            return events;
        }
    }
}