using DemoApp.QueryStack.Facade;
using DemoApp.Web.ViewModels;

namespace DemoApp.Web.Application
{
    public class HomeService
    {
        public IndexViewModel GetIndexViewModel()
        {
            var facade = new MatchFacade();
            var model = new IndexViewModel { ScheduledMatches = facade.FindScheduled() };
            return model;
        }
    }
}