using System.Collections.Generic;
using DemoApp.QueryStack.Model;

namespace DemoApp.Web.Models
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel()
        {
            Id = "";
            Team1 = "";
            Team2 = "";
            Matches = new List<Match>();
        }

        public IList<Match> Matches { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Id { get; set; }
    }
}