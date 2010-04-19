using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using OpenTimeline.Core.Domain;


namespace OpenTimeline.Core.Repositories
{
    public class TimelineRepository : Repository<Timeline>, ITimelineRepository
    {
        public TimelineRepository(ISession session) : base(session)
        {
        }

        #region Implementation of ITimelineRepository

        public IEnumerable<Timeline> FindByAccount(int accountId)
        {
            var members = (from x in _session.Linq<Member>()
                                                     where x.Account.Id == accountId
                                                     select x).ToList();
            var timelines = members.Select(x => x.Timeline);
            return timelines;
        }

        #endregion
    }
}