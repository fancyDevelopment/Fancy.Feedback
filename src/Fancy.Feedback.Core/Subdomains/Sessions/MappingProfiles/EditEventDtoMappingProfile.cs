using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles
{
    public class EditEventDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EditEventDto, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}