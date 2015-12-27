using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;

namespace Fancy.Feedback.WebApp.MappingProfiles
{
    public class EventVmMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EventVm, EventDto>();
            CreateMap<EventDto, EventVm>();
        }
    }
}