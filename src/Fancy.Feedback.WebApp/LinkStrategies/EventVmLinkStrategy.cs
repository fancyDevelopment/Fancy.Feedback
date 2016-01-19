using System;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class EventVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (EditEventVm);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            EditEventVm eventVm = (EditEventVm)resource;

            resource.AddLink("self", urlHelper.LinkTo<EventsController>(c => c.GetById(eventVm.Id)));

            if (eventVm.Id == 0)
            {
                // The event is not yet persisted and can be created
                resource.AddAction("create", "PUT", urlHelper.LinkTo<EventsController>(c => c.Create(null)));
            }
        }
    }
}