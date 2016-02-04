using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles
{
    public class EventDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.SessionCount, opt => opt.MapFrom(src => src.Sessions.Count));

        }
    }
}