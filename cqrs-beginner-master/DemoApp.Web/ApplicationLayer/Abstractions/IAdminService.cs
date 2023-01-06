using DemoApp.Web.Models;

namespace DemoApp.Web.ApplicationLayer.Abstractions
{
    public interface IAdminService
    {
        RegisterViewModel GetAdminViewModel();
        void Register(RegisterInputModel input);
    }
}