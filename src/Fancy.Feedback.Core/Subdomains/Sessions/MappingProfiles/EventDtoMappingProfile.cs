using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles
{
    public class EventDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>();
        }
    }
}