using System;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class DashboardVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (DashboardVm);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            resource.AddLink("self", urlHelper.LinkTo<DashboardController>(c => c.Index()));
            resource.AddAction("event-create", "PUT", urlHelper.LinkTo<EventsController>(c => c.Create(null)));
        }
    }
}