using System.Linq;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;

namespace DemoApp.QueryStack.DataAccess.Extensions 
{
    public static class BookingExtensions
    {
        public static IQueryable<Booking> ForCourts(this IQueryable<Booking> bookings, params int[] courtIds)
        {
            return bookings.Where(b => courtIds.Contains(b.CourtId));
        }
    }
}