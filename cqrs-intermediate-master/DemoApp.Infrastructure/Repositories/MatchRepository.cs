using System.Linq;
using DemoApp.Infrastructure.Common;
using DemoApp.Infrastructure.Data;

namespace DemoApp.Infrastructure.Repositories
{
    public class MatchRepository
    {
        private readonly DemoAppEntities _database = new DemoAppEntities();

        public Match FindById(string id)
        {
            var match = (from m in _database.Matches where m.Id == id select m).FirstOrDefault();
            return match;
        }

        public void DeleteById(string id)
        {
            var match = FindById(id);
            if (match == null)
                return;

            _database.Matches.Remove(match);
            _database.SaveChanges();
        }

        public void Save(Match match)
        {
            var existing = FindById(match.Id);
            if (existing == null)
            {
                _database.Matches.Add(match);
            }
            else
            {
                match.CopyPropertiesTo(existing);
            }
            _database.SaveChanges();
        }

        public IQueryable<Match> Find()
        {
            var list = (from m in _database.Matches select m);
            return list;
        }
    }
}