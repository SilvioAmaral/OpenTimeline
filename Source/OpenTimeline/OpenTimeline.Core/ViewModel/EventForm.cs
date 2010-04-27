using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenTimeline.Core.ViewModel
{
    public class EventForm
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TimelineName { get; set; }
        public int TimelineId { get; set; }
        public IEnumerable<SelectListItem> Timelines { get; set; }
        public IEnumerable<EventForm.EventViewModel> Events { get; set; }

        public class EventViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}