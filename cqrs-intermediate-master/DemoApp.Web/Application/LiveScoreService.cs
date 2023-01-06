using DemoApp.QueryStack.Facade;
using DemoApp.Web.ViewModels;

namespace DemoApp.Web.Application
{
    public class LiveScoreService
    {
        public LiveViewModel GetLiveViewModel()
        {
            var facade = new MatchFacade();
            var model = new LiveViewModel { LiveMatches = facade.FindInProgress() };
            return model;
        }
    }
}