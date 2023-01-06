using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoApp.SharedKernel
{
    public class SlotHistory
    {
        public SlotHistory()
        {
            ChangeList = new List<SlotInfo>();
        }

        public int BookingId { get; set; }
        public IList<SlotInfo> ChangeList { get; set; }

        public JavaScriptSlotHistory ToJavaScriptSlotHistory()
        {
            var dto = new JavaScriptSlotHistory
            {
                BookingId = BookingId,
                ChangeList = ToJavaScriptSlotInfo(ChangeList)
            };
            return dto;
        }

        private IList<JavaScriptSlotInfo> ToJavaScriptSlotInfo(IEnumerable<SlotInfo> changes)
        {
            var sorted = changes.OrderBy(c => c.When);
            var list = new List<JavaScriptSlotInfo>();
            var last = new SlotInfo();
            foreach (var change in sorted)
            {
                var jsSlot = new JavaScriptSlotInfo
                {
                    CourtId = change.CourtId <= 0 || change.CourtId == last.CourtId
                        ? ""
                        : change.CourtId.ToString(),
                    StartingAt = change.StartingAt <= 0 || change.StartingAt == last.StartingAt
                        ? ""
                        : change.StartingAt.ToString(),
                    Length = change.Length <= 0 || change.Length == last.Length
                        ? ""
                        : change.Length.ToString(),
                    Name = String.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Action = String.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When.ToString("dd MMM yyyy HH:mm")
                };

                list.Add(jsSlot);
                
                // Save last change 
                last = change;
            }
            return list;
        }
    }
}