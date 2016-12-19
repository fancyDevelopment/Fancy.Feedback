using AutoMapper;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.SchemaFormBuilder.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fancy.Feedback.WebApp.Controllers
{
    /// <summary>
    /// Web controller to manager the event resources.
    /// </summary>
    public class EventsController : Controller
    {
        /// <summary>
        /// The events service.
        /// </summary>
        private readonly IEventsService _eventsService;

        /// <summary>
        /// The schema form builder.
        /// </summary>
        private readonly ISchemaFormBuilder _schemaFormBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="eventsService">The events service.</param>
        /// <param name="schemaFormBuilder">The schema form builder.</param>
        public EventsController(IEventsService eventsService, ISchemaFormBuilder schemaFormBuilder)
        {
            _eventsService = eventsService;
            _schemaFormBuilder = schemaFormBuilder;
        }

        /// <summary>
        /// Finds events by a specified name filter.
        /// </summary>
        /// <param name="nameFilter">The name filter.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>One page of the search result containing events.</returns>
        [HttpGet]
        [Route("[controller]")]
        public IActionResult Find(string nameFilter = null, int page = 1, int pageSize = 30)
        {
            PagedResultSet<EventDto> pagedSeachResult = _eventsService.Find(nameFilter, page, pageSize);

            // Link resource to related web controller operations
            this.LinkResource(pagedSeachResult);

            return Json(pagedSeachResult);
        }

        /// <summary>
        /// Gets an event by a specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An event.</returns>
        [HttpGet]
        [Route("[controller]/{id}", Name = "events-byId")]
        public IActionResult GetById(int id)
        {
            EventDto eventDto = _eventsService.GetById(id);

            // Link resource to related web controller operations
            this.LinkResource(eventDto);

            return Json(eventDto);
        }

        /// <summary>
        /// Delivers the metadata description required to create a new instance of an event resource.
        /// </summary>
        /// <returns>Resource metadata to be used to create a new resource instance.</returns>
        [HttpGet]
        [Route("[controller]/create", Name = "events-create-desc")]
        public IActionResult CreateDesc()
        {
            // Create the schema and form description
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(EditEventVm));
            ResourceMeta<EditEventVm> resourceMeta = new ResourceMeta<EditEventVm>();
            resourceMeta.Schema = schemaFormInfo.Schema;
            resourceMeta.Form = schemaFormInfo.Form;
            resourceMeta.Model = new EditEventVm();

            // Link resource to related web controller operations
            this.LinkResource(resourceMeta);

            return Json(resourceMeta);
        }

        /// <summary>
        /// Creates a new instance of an event.
        /// </summary>
        /// <param name="editEventVm">The edit event view model.</param>
        /// <returns>The created resource.</returns>
        [HttpPut]
        [Route("[controller]", Name = "events-create")]
        public IActionResult Create([FromBody] EditEventVm editEventVm)
        {
            EditEventDto editEventDto = Mapper.Map<EditEventDto>(editEventVm);
            int eventId = _eventsService.Create(editEventDto);
            EventDto eventDto = _eventsService.GetById(eventId);

            // Link resource to related web controller operations
            this.LinkResource(eventDto);

            return Json(eventDto);
        }

        /// <summary>
        /// Updates an existing event resource with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="editEventVm">The edit event view model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]/{id}", Name = "events-update")]
        public IActionResult Update(int id, [FromBody] EditEventVm editEventVm)
        {
            EditEventDto editEventDto = Mapper.Map<EditEventDto>(editEventVm);
            _eventsService.Update(id, editEventDto);
            EventDto eventDto = _eventsService.GetById(id);

            // Link resource to related web controller operations
            this.LinkResource(eventDto);

            return Json(eventDto);
        }
    }
}