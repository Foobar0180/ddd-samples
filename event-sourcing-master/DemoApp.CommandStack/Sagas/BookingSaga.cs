using DemoApp.CommandStack.Commands;
using DemoApp.CommandStack.Domain.Model;
using DemoApp.CommandStack.Events;
using DemoApp.Infrastructure.Framework;
using DemoApp.Infrastructure.Framework.EventStore;
using DemoApp.Infrastructure.Framework.Repositories;
using DemoApp.Infrastructure.Persistence.SqlServer.Repositories;

namespace DemoApp.CommandStack.Sagas
{
    public class BookingSaga : Saga,
        IStartWithMessage<RequestBookingCommand>,
        IHandleMessage<EditBookingCommand>
    {
        private readonly IRepository _repository;

        public BookingSaga(IBus bus, IEventStore eventStore)
            : base(bus, eventStore)
        {
            _repository = new BookingRepository();
        }

        public BookingSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore)
        {
            _repository = repository;
        }

        public void Handle(RequestBookingCommand message)
        {
            var request = BookingRequest.Factory.Create(message.CourtId, message.Hour, message.Length, message.UserName,
                message.Notes);
            var response = _repository.CreateBookingFromRequest(request);
            if (!response.Success)
            {
                var rejected = new BookingRequestRejectedEvent(request.Id, response.Description);
                Bus.RaiseEvent(rejected);
                return;
            }

            var slotInfo = request.ToSlotInfo();
            var created = new BookingCreatedEvent(request.Id, response.AggregateId, slotInfo);
            Bus.RaiseEvent(created);
        }

        public void Handle(EditBookingCommand message)
        {
            var response = _repository.Update(message.BookingId, message.Hour, message.Length, message.UserName);
            if (response.Success)
            {
                var updated = new BookingUpdatedEvent(message.BookingId, message.Hour, message.UserName, message.Length);
                Bus.RaiseEvent(updated);
            }
        }
    }
}