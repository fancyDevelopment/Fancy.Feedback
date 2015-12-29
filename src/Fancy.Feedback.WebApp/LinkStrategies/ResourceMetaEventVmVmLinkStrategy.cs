using System;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class ResourceMetaEventVmVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (ResourceMeta<EventVm>);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            ResourceMeta<EventVm> eventVm = (ResourceMeta<EventVm>)resource;
            
            resource.AddLink("self", urlHelper.LinkTo<EventsController>(c => c.Create()));
        }
    }
}