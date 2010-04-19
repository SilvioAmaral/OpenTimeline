using System.Collections.Generic;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.Repositories
{
    public interface ITimelineRepository : IRepository<Timeline>
    {
        IEnumerable<Timeline> FindByAccount(int accountId);
    }
}