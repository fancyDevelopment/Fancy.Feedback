﻿using System;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class ResourceMetaEventVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (ResourceMeta<EditEventVm>);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            ResourceMeta<EditEventVm> eventVm = (ResourceMeta<EditEventVm>)resource;
            
            resource.AddLink("self", urlHelper.LinkTo<EventsController>(c => c.CreateDesc()));
        }
    }
}