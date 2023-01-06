using System.Web.Mvc;
using DemoApp.Web.Application;
using DemoApp.Web.Common.Actions;
using DemoApp.Web.ViewModels;

namespace DemoApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService = new AdminService();

        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        [HttpPost]
        public ActionResult Action(AdminAction action)
        {
            _adminService.ProcessAction(action);
            return RedirectToAction("index", "home");
        }
    }
}