using System.Web.Mvc;
using DemoApp.Web.Application;

namespace DemoApp.Web.Controllers
{
    public class LiveController : Controller
    {
        private readonly LiveScoreService _liveScoreService = new LiveScoreService();

        public ActionResult Index()
        {
            var model = _liveScoreService.GetLiveViewModel();
            return View(model);
        }

        public PartialViewResult Update()
        {
            var model = _liveScoreService.GetLiveViewModel();
            return PartialView("_live", model);
        }
    }
}