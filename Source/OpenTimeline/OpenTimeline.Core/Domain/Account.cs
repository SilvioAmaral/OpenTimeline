using Iesi.Collections.Generic;

namespace OpenTimeline.Core.Domain
{
    public class Account
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Website { get; set; }

        public virtual string Password { get; set; }

        public virtual int Version { get; set; }

        public virtual ISet<Member> Members { get; set; }
    }
}