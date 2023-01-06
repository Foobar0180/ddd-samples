using System.Collections.Generic;
using DemoApp.QueryStack.Model;

namespace DemoApp.Web.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public IList<CourtSchedule> CourtSchedules { get; set; }
    }
}