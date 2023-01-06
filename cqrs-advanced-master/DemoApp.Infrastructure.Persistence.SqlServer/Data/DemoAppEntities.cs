using System.Data.Entity;

namespace DemoApp.Infrastructure.Persistence.SqlServer.Data
{
    public partial class DemoAppEntities : DbContext
    {
        public DemoAppEntities()
            : base("name=DemoAppEntities")
        { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Court> Courts { get; set; }
    }
}