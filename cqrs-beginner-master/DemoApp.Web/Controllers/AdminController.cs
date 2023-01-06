using System.Web.Mvc;
using DemoApp.Web.ApplicationLayer;
using DemoApp.Web.ApplicationLayer.Abstractions;
using DemoApp.Web.Models;

namespace DemoApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService; 

        public AdminController() : this(new AdminService())
        { }

        public AdminController(IAdminService service)
        {
            _adminService = service;
        }

        [HttpGet]
        [ActionName("Register")]
        public ActionResult DisplayRegister()
        {
            // Perform the query
            var model = _adminService.GetAdminViewModel();
            return View(model);
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult PostRegister(RegisterInputModel input)
        {
            // Perform the command
            _adminService.Register(input);

            // Re-routes
            return RedirectToAction("register");
        }
    }
}