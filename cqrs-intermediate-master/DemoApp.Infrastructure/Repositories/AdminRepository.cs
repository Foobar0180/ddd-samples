using DemoApp.Infrastructure.Data;

namespace DemoApp.Infrastructure.Repositories
{
    public class AdminRepository
    {
        private readonly DemoAppEntities _database = new DemoAppEntities();

        public void ResetDb()
        {
            // Empty both DBs
            foreach (var m in _database.Matches)
            {
                _database.Matches.Remove(m);
            }
            foreach (var mev in _database.MatchEvents)
            {
                _database.MatchEvents.Remove(mev);
            }
            _database.SaveChanges();
        }
    }
}