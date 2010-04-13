using Iesi.Collections.Generic;

namespace OpenTimeline.Core.Domain
{
    public class Member
    {
        public virtual int? Id { get; set; }

        public virtual Account Account { get; set; }

        public virtual Timeline Timeline { get; set; }

        public virtual ISet<MemberEvent> MemberEvents { get; set; }

        public virtual bool IsAdmin { get; set; }
    }
}