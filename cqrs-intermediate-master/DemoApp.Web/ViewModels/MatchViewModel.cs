using DemoApp.QueryStack.Dto;

namespace DemoApp.Web.ViewModels
{
    public class MatchViewModel : ViewModelBase
    {
        public MatchViewModel()
        {
            Current = new MatchInProgress();
            Actions = new MatchAllowedActions();
        }

        public MatchAllowedActions Actions { get; set; }
        public MatchInProgress Current { get; set; }
    }
}
