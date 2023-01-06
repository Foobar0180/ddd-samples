using System.Data.Entity;
using DemoApp.CommandStack.Model;

namespace DemoApp.CommandStack
{
    public class CommandDbContext : DbContext
    {
        public CommandDbContext()
            : base("name=DemoAppEntities")
        { }

        public virtual DbSet<Match> Matches { get; set; }
    }
}
