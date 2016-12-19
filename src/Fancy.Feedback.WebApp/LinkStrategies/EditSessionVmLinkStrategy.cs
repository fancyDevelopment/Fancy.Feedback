using System;
using Fancy.Feedback.WebApp.Controllers;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.ResourceLinker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fancy.Feedback.WebApp.LinkStrategies
{
    public class EditSessionVmLinkStrategy : ILinkStrategy
    {
        public bool CanLinkType(Type type)
        {
            return type == typeof (EditSessionVm);
        }

        public void LinkResource(ResourceBase resource, IUrlHelper urlHelper)
        {
            EditSessionVm editSessionVm = (EditSessionVm)resource;

            resource.AddLink("self", urlHelper.LinkTo<SessionsController>(c => c.GetById(editSessionVm.Id)));

            if (editSessionVm.Id == 0)
            {
                // The event is not yet persisted and can be created
                resource.AddAction("create", "PUT", urlHelper.LinkTo<SessionsController>(c => c.Create(null)));
            }
        }
    }
}