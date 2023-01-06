using DemoApp.CommandStack.Domain.Model;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;

namespace DemoApp.CommandStack.Domain.Services.Adapter
{
    public class Adapter 
    {
        public static Booking ToDataModel(BookingRequest entity)
        {
            var booking = new Booking
            {
                CourtId = entity.CourtId,
                Length = entity.Length,
                Name = entity.Name,
                StartingAt = entity.Hour,
                RequestId = entity.Id.ToString()
            };
            return booking;
        }
    }
}