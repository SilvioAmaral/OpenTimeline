using FluentNHibernate.Mapping;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class MemberMap : ClassMap<Domain.Member>
    {
        public MemberMap()
        {
            Table("Member");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IsAdmin);
            References(x => x.Timeline, "TimelineId").Fetch.Join();
            References(x => x.Account, "AccountId").Fetch.Join();
            HasMany(x => x.MemberEvents).KeyColumns.Add("MemberId").AsSet().Inverse().Cascade.All();
        }
    }
}