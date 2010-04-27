using System;
using Iesi.Collections.Generic;

namespace OpenTimeline.Core.Domain
{
    public class Timeline
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual int Version { get; set; }

        public virtual ISet<Event> Events { get; set; }

        public virtual ISet<Member> Members { get; set; }

        public Timeline()
        {
            Events = new HashedSet<Event>();
            Members = new HashedSet<Member>();
        }

        public virtual Member AddMember(Member member)
        {
            member.Timeline = this;
            Members.Add(member);
            return member;
        }

        public virtual Event AddEvent(Event @event)
        {
            @event.Timeline = this;
            Events.Add(@event);
            return @event;
        }
    }
}