using DemoApp.CommandStack.Model;
using DemoApp.Infrastructure.Repositories;
using DemoApp.Web.Application.SignalR;
using DemoApp.Web.Common.Actions;

namespace DemoApp.Web.Application
{
    public class AdminService
    {
        public void ProcessAction(AdminAction action)
        {
            var repository = new AdminRepository();
            var matchService = new MatchService();

            switch (action)
            {
                case AdminAction.ResetDb:
                    repository.ResetDb();
                    matchService.ProcessAction("WP0001", EventType.Created, "Frogs", "Sharks");
                    matchService.ProcessAction("WP0002", EventType.Created, "Sharks", "Eels");
                    break;
            }
            LiveScoreHub.Refresh();
        }
    }
}