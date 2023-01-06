using System.Collections.Generic;
using DemoApp.QueryStack.Dto;

namespace DemoApp.Web.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public IList<MatchListItem> ScheduledMatches { get; set; }
    }
}
