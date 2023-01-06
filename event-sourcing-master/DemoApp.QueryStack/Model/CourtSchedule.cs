using System.Collections.Generic;

namespace DemoApp.QueryStack.Model
{
    public class CourtSchedule
    {
        public CourtSchedule()
        {
            Slots = new List<Slot>();
            CourtName = string.Empty;
        }

        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public IList<Slot> Slots { get; set; }
    }
}