using System.Collections.Generic;
using AutoMapper;
using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.SchemaFormBuilder.Services;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly ISchemaFormBuilder _schemaFormBuilder;

        public EventsController(IEventsService eventsService, ISchemaFormBuilder schemaFormBuilder)
        {
            _eventsService = eventsService;
            _schemaFormBuilder = schemaFormBuilder;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAll()
        {
            IEnumerable<EventDto> eventDtos = _eventsService.GetAllEvents();
            IEnumerable<EventVm> eventVms = Mapper.Map<IEnumerable<EventVm>>(eventDtos);

            return Json(eventVms);
        }

        [HttpGet]
        [Route("[controller]/meta")]
        public IActionResult Meta()
        {
            // Create the schema and form description
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(EventVm));
            ResourceMetaVm resourceMetaVm = new ResourceMetaVm();
            resourceMetaVm.Schema = schemaFormInfo.Schema;
            resourceMetaVm.Form = schemaFormInfo.Form;

            return Json(resourceMetaVm);
        }

    }
}