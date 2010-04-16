using FluentNHibernate.Mapping;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class MemberEventMap : ClassMap<MemberEvent>
    {
        public MemberEventMap()
        {
            Table("MEMBER_EVENT");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Version).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
            References(x => x.Member, "MemberId").Fetch.Join();
            References(x => x.Event, "EventId").Fetch.Join();
        }
    }
}