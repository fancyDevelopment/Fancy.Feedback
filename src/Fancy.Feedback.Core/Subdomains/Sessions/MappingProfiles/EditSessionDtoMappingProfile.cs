using AutoMapper;

using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles
{
    public class EditSessionDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EditSessionDto, Session>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}