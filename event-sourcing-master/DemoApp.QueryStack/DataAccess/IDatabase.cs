using System.Linq;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;

namespace DemoApp.QueryStack.DataAccess
{
    public interface IDatabase
    {
        IQueryable<Booking> Bookings { get; }
        IQueryable<Court> Courts { get; }
    }
}