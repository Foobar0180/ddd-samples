using System.Linq;
using DemoApp.CommandStack.Commands;
using DemoApp.CommandStack.Domain.Services;
using DemoApp.QueryStack.DataAccess;
using DemoApp.QueryStack.Model;
using DemoApp.SharedKernel;

namespace DemoApp.Web.Application
{
    public class BookingService
    {
        #region Command stack endpoints

        public void AddBooking(int courtId, int hour, int length, string name, string notes)
        {
            // Place the command to the bus
            var command = new RequestBookingCommand(
                courtId,
                hour,
                length,
                name,
                notes
                );
            BookingApplication.Bus.Send(command);
        }

        public void EditBooking(int bookingId, int hour, string name, int length)
        {
            // Place the command to the bus
            var command = new EditBookingCommand(
                bookingId,
                hour,
                name,
                length
                );
            BookingApplication.Bus.Send(command);
        }

        #endregion


        #region Query stack endpoints

        public Slot GetBooking(int id)
        {
            var db = new Database();
            var booking = (from b in db.Bookings where b.Id == id select b).FirstOrDefault();
            if (booking != null)
            {
                var slot = new Slot { BookingId = booking.Id, Name = booking.Name, Length = booking.Length, StartingAt = booking.StartingAt };
                return slot;
            }
            return new Slot();
        }

        public SlotHistory History(int id)
        {
            var history = new HistoryService().GetHistory(id);
            return history;
        }

        #endregion
    }
}