using FluentNHibernate.Mapping;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class EventMap : ClassMap<Domain.Event>
    {
        public EventMap()
        {
            Table("Event");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.Version);
            HasMany(x => x.MemberEvents).KeyColumns.Add("EventId").AsSet().Inverse().Cascade.All();
        }

    }
}