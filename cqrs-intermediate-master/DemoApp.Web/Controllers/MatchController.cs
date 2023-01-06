using System;
using System.Web.Mvc;
using DemoApp.CommandStack.Model;
using DemoApp.Web.Application;

namespace DemoApp.Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly MatchService _matchService = new MatchService();

        public ActionResult Index(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                return RedirectToAction("index", "home");

            var model = _matchService.GetMatchDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Action(string id, EventType whatHappened)
        {
            _matchService.ProcessAction(id, whatHappened);
            return RedirectToAction("index", new {id = id});
        }
    }
}