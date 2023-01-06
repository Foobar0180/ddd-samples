using System.Data.Entity;
using DemoApp.QueryStack.Model;

namespace DemoApp.QueryStack
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext()
            : base("name=DemoAppEntities")
        { }

        public virtual DbSet<Match> Matches { get; set; }
    }
}
