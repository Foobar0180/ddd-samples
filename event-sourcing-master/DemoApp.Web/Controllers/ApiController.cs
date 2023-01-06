using System.Web.Mvc;
using DemoApp.Web.Application;

namespace DemoApp.Web.Controllers
{
    public class ApiController : Controller
    {
        private readonly BookingService _service = new BookingService();

        public JsonResult Booking(int id)
        {
            var booking = _service.GetBooking(id);
            return Json(booking, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BookingHistory(int id)
        {
            var history = _service.History(id);
            var dto = history.ToJavaScriptSlotHistory();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }
    }
}