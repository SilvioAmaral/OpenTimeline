using FluentNHibernate.Mapping;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.NHibernate.Mapping
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("Account");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.DisplayName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Website);
            Map(x => x.Version).Not.Nullable();
            HasMany(x => x.Members).KeyColumns.Add("AccountId").AsSet().Inverse().Cascade.All();
        }
    }
}