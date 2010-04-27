using System.Web.Mvc;
using AutoMapper;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Core.Infra.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<MemberEvent, MemberTimelineViewModel.EventViewModel>();
            Mapper.CreateMap<Timeline, SelectListItem>()
                .ForMember(x => x.Text, m => m.MapFrom(s => s.Name))
                .ForMember(x => x.Value, m => m.MapFrom(s => s.Id));
            Mapper.CreateMap<Member, MemberTimelineViewModel>()
                .ForMember(x => x.Events, m => m.MapFrom(s => s.MemberEvents));
        }
    }
}