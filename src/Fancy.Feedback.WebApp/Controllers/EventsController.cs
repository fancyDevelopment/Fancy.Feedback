using AutoMapper;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
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
        public IActionResult Find(string nameFilter = null, int page = 1, int pageSize = 30)
        {
            PagedResultSet<EventDto> eventDtos = _eventsService.Find(nameFilter, page, pageSize);
            PagedResultSet<EditEventVm> eventVms = eventDtos.ConvertTo<EditEventVm>();

            return Json(eventVms);
        }

        [HttpGet]
        [Route("[controller]/{id}", Name = "events-byId")]
        public IActionResult GetById(int id)
        {
            EventDto eventDto = _eventsService.GetById(id);
            EditEventVm eventVm = Mapper.Map<EditEventVm>(eventDto);

            return Json(eventVm);
        }

        [HttpGet]
        [Route("[controller]/create", Name = "events-create-desc")]
        public IActionResult Create()
        {
            // Create the schema and form description
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(EditEventVm));
            ResourceMeta<EditEventVm> resourceMeta = new ResourceMeta<EditEventVm>();
            resourceMeta.Schema = schemaFormInfo.Schema;
            resourceMeta.Form = schemaFormInfo.Form;
            resourceMeta.Model = new EditEventVm();

            this.LinkResource(resourceMeta);

            return Json(resourceMeta);
        }

        [HttpPut]
        [Route("[controller]", Name = "events-create")]
        public int Create([FromBody] EditEventVm editEventVm)
        {
            EditEventDto editEventDto = Mapper.Map<EditEventDto>(editEventVm);
            return _eventsService.Save(editEventDto);
        }

        [HttpPost]
        [Route("[controller]/{id}", Name = "events-update")]
        public int Update(int id, [FromBody] EditEventVm editEventVm)
        {
            EditEventDto editEventDto = Mapper.Map<EditEventDto>(editEventVm);
            _eventsService.Update(id, editEventDto);
            return id;
        }
    }
}