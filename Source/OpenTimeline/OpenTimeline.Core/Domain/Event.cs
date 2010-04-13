using Iesi.Collections.Generic;

namespace OpenTimeline.Core.Domain
{
    public class Event
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual int Version { get; set; }

        public virtual ISet<MemberEvent> MemberEvents { get; set; }

        public virtual Timeline Timeline { get; set; }
    }
}