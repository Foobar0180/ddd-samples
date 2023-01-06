using System.Collections.Generic;
using DemoApp.QueryStack.Dto;

namespace DemoApp.Web.ViewModels
{
    public class LiveViewModel : ViewModelBase
    {
        public LiveViewModel()
        {
            LiveMatches = new List<MatchInProgress>();
        }

        public IList<MatchInProgress> LiveMatches { get; set; }
    }
}
