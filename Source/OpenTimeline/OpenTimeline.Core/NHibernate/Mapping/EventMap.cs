using FluentNHibernate.Mapping;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Table("Event");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.Version);
            References(x => x.Timeline, "TimelineId").Fetch.Join();
            HasMany(x => x.MemberEvents).KeyColumns.Add("EventId").AsSet().Inverse().Cascade.All();
        }
    }
}