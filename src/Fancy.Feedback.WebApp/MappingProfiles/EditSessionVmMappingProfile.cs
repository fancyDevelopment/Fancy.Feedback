using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;

namespace Fancy.Feedback.WebApp.MappingProfiles
{
    public class EditSessionVmMappingProfile : Profile
    {
        public EditSessionVmMappingProfile()
        {
            CreateMap<EditSessionVm, EditSessionDto>();
            CreateMap<EditSessionDto, EditSessionVm>();
        }
    }
}