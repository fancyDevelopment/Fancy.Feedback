﻿using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;

namespace Fancy.Feedback.WebApp.MappingProfiles
{
    public class EditEventVmMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<EditEventVm, EditEventDto>();
            CreateMap<EditEventDto, EditEventVm>();
        }
    }
}