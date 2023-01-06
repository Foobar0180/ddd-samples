using DemoApp.CommandStack.Handlers;
using DemoApp.CommandStack.Sagas;
using DemoApp.Infrastructure.Framework;
using DemoApp.Infrastructure.Framework.EventStore;

namespace DemoApp.Web
{
    public class BusConfig
    {
        public static void Initialize()
        {
            BookingApplication.Bus = new InMemoryBus(new SqlEventStore());

            BookingApplication.Bus.RegisterSaga<BookingSaga>();
            BookingApplication.Bus.RegisterHandler<BookingRejectedHandler>();
            BookingApplication.Bus.RegisterHandler<EmailHandler>();
        }
    }
}