using FluentNHibernate.Mapping;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class TimelineMap : ClassMap<Timeline>
    {
        public TimelineMap()
        {
            Table("Timeline");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.CreatedOn);
            Map(x => x.Version);
            HasMany(x => x.Members).KeyColumns.Add("TimelineId").AsSet().Inverse().Cascade.All();
            HasMany(x => x.Events).KeyColumns.Add("TimelineId").AsSet().Inverse().Cascade.All();
        }
    }
}