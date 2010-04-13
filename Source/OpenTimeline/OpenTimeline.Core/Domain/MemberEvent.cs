using System;

namespace OpenTimeline.Core.Domain
{
    public class MemberEvent
    {
        public virtual int? Id { get; set; }

        public virtual Member Member { get; set; }

        public virtual Event Event { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Version { get; set; }
    }
}