using System.Linq;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;

namespace DemoApp.QueryStack.DataAccess
{
    public class Database : IDatabase
    {
        private readonly DemoAppEntities _database;

        public Database()
        {
            _database = new DemoAppEntities();
        }

        public IQueryable<Booking> Bookings => _database.Bookings;

        public IQueryable<Court> Courts => _database.Courts;
    }
}