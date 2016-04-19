using AutoMapper;

using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Fancy.SchemaFormBuilder.Services;

using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.Controllers
{
    /// <summary>
    /// Web controller to manage session resources.
    /// </summary>
    public class SessionsController : Controller
    {
        /// <summary>
        /// The session service.
        /// </summary>
        private readonly ISessionService _sessionService;

        /// <summary>
        /// The schema form builder
        /// </summary>
        private readonly ISchemaFormBuilder _schemaFormBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionsController"/> class.
        /// </summary>
        /// <param name="schemaFormBuilder">The schema form builder.</param>
        public SessionsController(ISessionService sessionService, ISchemaFormBuilder schemaFormBuilder)
        {
            _sessionService = sessionService;
            _schemaFormBuilder = schemaFormBuilder;
        }

        /// <summary>
        /// Gets a session by a specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A session.</returns>
        [HttpGet]
        [Route("[controller]/{id}", Name = "sessions-byId")]
        public IActionResult GetById(int id)
        {
            SessionDto sessionDto = _sessionService.GetById(id);

            // Link resource to related web controller operations
            this.LinkResource(sessionDto);

            return Json(sessionDto);
        }

        /// <summary>
        /// Delivers the metadata description required to create a new instance of a session resource.
        /// </summary>
        /// <param name="eventId">The event identifier the created session shall belong to.</param>
        /// <returns>
        /// Resource metadata to be used to create a new resource instance.
        /// </returns>
        [HttpGet]
        [Route("[controller]/create", Name = "sessions-create-desc")]
        public IActionResult CreateDesc(int eventId)
        {
            // Create the schema and form description
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(EditEventVm));
            ResourceMeta<EditSessionDto> resourceMeta = new ResourceMeta<EditSessionDto>();
            resourceMeta.Schema = schemaFormInfo.Schema;
            resourceMeta.Form = schemaFormInfo.Form;
            resourceMeta.Model = new EditSessionDto();
            resourceMeta.Model.EventId = eventId;

            // Link resource to related web controller operations
            this.LinkResource(resourceMeta);

            return Json(resourceMeta);
        }

        /// <summary>
        /// Creates a new instance of a session.
        /// </summary>
        /// <param name="editSessionVm">The edit session view model.</param>
        /// <returns>The created resource.</returns>
        [HttpPut]
        [Route("[controller]", Name = "sessions-create")]
        public IActionResult Create([FromBody] EditSessionVm editSessionVm)
        {
            EditSessionDto editSessionDto = Mapper.Map<EditSessionDto>(editSessionVm);
            long sessionId = _sessionService.Create(editSessionDto);
            SessionDto sessionDto = _sessionService.GetById(sessionId);

            // Link resource to related web controller operations
            this.LinkResource(sessionDto);

            return Json(sessionDto);
        }
    }
}