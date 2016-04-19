using System;

using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class EventVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (EventDto);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            EventDto eventDto = (EventDto)resource;

            resource.AddLink("self", urlHelper.LinkTo<EventsController>(c => c.GetById(eventDto.Id)));
            resource.AddLink("addSession", urlHelper.LinkTo<SessionsController>(c => c.CreateDesc(eventDto.Id)));
        }
    }
}