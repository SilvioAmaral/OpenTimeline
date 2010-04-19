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
        }
    }
}