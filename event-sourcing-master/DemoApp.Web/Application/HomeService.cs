using System.Collections.Generic;
using System.Linq;
using DemoApp.Infrastructure.Persistence.SqlServer.Data;
using DemoApp.QueryStack.DataAccess;
using DemoApp.QueryStack.DataAccess.Extensions;
using DemoApp.QueryStack.Model;
using DemoApp.Web.ViewModels;

namespace DemoApp.Web.Application
{
    public class HomeService
    {
        public IndexViewModel GetIndexViewModel()
        {
            var db = new Database();
            var courtSchedules = new List<CourtSchedule>();
            
            // Get booking for courts
            var courts = db.Courts.ToList();
            var courtIds = (from c in courts select c.Id).Distinct().ToArray();
            var bookings = db.Bookings.ForCourts(courtIds);

            foreach (var court in courts)
            {
                var schedule = GetScheduleForCourt(court, bookings.Where(b => b.CourtId == court.Id).ToList());
                courtSchedules.Add(schedule);
            }

            var model = new IndexViewModel {CourtSchedules = courtSchedules};
            return model;
        }

        private static CourtSchedule GetScheduleForCourt(Court court, IList<Booking> bookings)
        {
            var schedule = new CourtSchedule
            {
                CourtId = court.Id,
                CourtName = court.Name
            };

            for (var hour = court.FirstSlot; hour <= court.LastSlot; hour++)
            {
                var slot = new Slot {StartingAt = hour};

                var matchingBooking = (from b in bookings where b.StartingAt == hour select b).FirstOrDefault();
                if (matchingBooking != null)
                {
                    slot.BookingId = matchingBooking.Id;
                    slot.Name = matchingBooking.Name;
                    slot.Length = matchingBooking.Length;
                    if (slot.Length > 1)
                        hour += (slot.Length - 1);
                }
                schedule.Slots.Add(slot);
            }
            return schedule;
        }
    }
}