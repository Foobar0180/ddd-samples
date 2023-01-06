using System;
using DemoApp.CommandStack.Domain.Common;
using DemoApp.CommandStack.Domain.Model;
using DemoApp.Infrastructure.Framework;
using DemoApp.Infrastructure.Framework.Repositories;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;
using DemoApp.Infrastructure.Persistence.SqlServer.Repositories.Adapters;

namespace DemoApp.Infrastructure.Persistence.SqlServer.Repositories
{
    public class BookingRepository : IRepository
    {
        private readonly DemoAppEntities _database;
        public BookingRepository()
        {
            _database = new DemoAppEntities();
        }

        public T GetById<T>(int id) where T : IAggregate
        {
            throw new NotImplementedException();
        }

        public CommandResponse CreateBookingFromRequest<T>(T item) where T : class, IAggregate
        {
            // Gets a BookingRequest
            var request = item as BookingRequest;
            var booking = Adapter.RequestToBooking(request);
            
            _database.Bookings.Add(booking);
            var count = _database.SaveChanges();

            var response = new CommandResponse(count >0, booking.Id) {RequestId = new Guid(booking.RequestId)};
            return response;
        }
    }
}