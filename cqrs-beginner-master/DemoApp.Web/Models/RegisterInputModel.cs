namespace DemoApp.Web.Models
{
    public class RegisterInputModel  
    {
        public RegisterInputModel()
        {
            Id = "";
            Team1 = "";
            Team2 = "";
        }

        public string Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    }
}