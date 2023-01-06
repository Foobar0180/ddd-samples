using System.Collections.Generic;

namespace DemoApp.SharedKernel
{
    public class JavaScriptSlotHistory
    {
        public int BookingId { get; set; }
        public IList<JavaScriptSlotInfo> ChangeList { get; set; }
    }
}