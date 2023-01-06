using System;
using System.Linq;
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

            _database.Bookings.Add(booking); //.Set<T>().Add(booking);
            var count = _database.SaveChanges();

            var response = new CommandResponse(count >0, booking.Id) {RequestId = new Guid(booking.RequestId)};
            return response;
        }

        public CommandResponse Update(int bookingId, int hour, int length, string name)
        {
            //var current = DateTime.Now;
            //if (current.Second % 2 == 0)
            //{
            //    return CommandResponse.Fail;
            //}

            var booking = (from b in _database.Bookings where b.Id == bookingId select b).FirstOrDefault();
            if (booking == null)
                return CommandResponse.Fail;

            booking.Id = bookingId;
            booking.StartingAt = hour;
            booking.Length = length;
            booking.Name = name;
            var count = _database.SaveChanges();
            var response = new CommandResponse(count > 0, booking.Id);
            return response;
        }
    }
}