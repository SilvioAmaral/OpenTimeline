using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenTimeline.Core.ViewModel
{
    public class MemberTimelineViewModel
    {
        public IEnumerable<SelectListItem> Timelines { get; set; }
        public int TimelineId { get; set; }
        public string TimelineName { get; set; }
        public IEnumerable<MemberTimelineViewModel.EventViewModel> Events { get; set; }

        public MemberTimelineViewModel()
        {
            Timelines = new List<SelectListItem>();
            Events = new List<EventViewModel>();
        }
        public class TimelineViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public TimelineViewModel(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class EventViewModel
        {
            public string EventName { get; set; }
            public DateTime Date { get; set; }
        }
    }
}