using AutoMapper;

using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles
{
    public class SessionDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SessionDto, Session>();
            CreateMap<Session, SessionDto>();
        }
    }
}