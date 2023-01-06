using System.Linq;
using DemoApp.CommandStack;
using DemoApp.QueryStack;
using DemoApp.Web.ApplicationLayer.Abstractions;
using DemoApp.Web.Models;

namespace DemoApp.Web.ApplicationLayer
{
    public class AdminService : IAdminService
    {
        public RegisterViewModel GetAdminViewModel()
        {
            var model = new RegisterViewModel();
            using (var db = new Database())
            {
                var list = (from m in db.Matches select m).ToList();
                model.Matches = list;
            }

            return model;
        }

        public void Register(RegisterInputModel input)
        {
            // Push a command through the stack
            using (var db = new CommandDbContext())
            {
                var match = new CommandStack.Model.Match { Id=input.Id, Team1 = input.Team1, Team2 = input.Team2 };
                db.Matches.Add(match);
                db.SaveChanges();
            }
        }
    }
}