using DemoApp.CommandStack.Commands;

namespace DemoApp.Web.Application
{
    public class BookingService
    {
        public void AddBooking(int courtId, int hour, int length, string name)
        {
            // Place the command to the bus
            var command = new RequestBookingCommand(
                courtId,
                hour,
                length,
                name
                );
            BookingApplication.Bus.Send(command);
        }
    }
}