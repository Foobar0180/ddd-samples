using System.Collections.Generic;

namespace DemoApp.Infrastructure.Persistence.SqlServer.Data
{
    public partial class Court
    {
        public Court()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstSlot { get; set; }
        public int LastSlot { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
