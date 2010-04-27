using System.Web.Mvc;
using AutoMapper;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Core.Config
{
    public class AutoMapperStartupTask : IStartupTask
    {
        #region Implementation of IStartupTask

        public void Execute()
        {
            Mapper.CreateMap<MemberEvent, MemberTimelineViewModel.EventViewModel>();
            Mapper.CreateMap<Timeline, SelectListItem>()
                .ForMember(x => x.Text, m => m.MapFrom(s => s.Name))
                .ForMember(x => x.Value, m => m.MapFrom(s => s.Id));
            Mapper.CreateMap<Member, MemberTimelineViewModel>()
                .ForMember(x => x.Events, m => m.MapFrom(s => s.MemberEvents));
        }

        #endregion
    }
}