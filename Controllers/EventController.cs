using AutoMapper;
using EndavaProject.Models.DTOs;
using EndavaProject.Repositories.EventRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EndavaProject.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{id}")]
        public async Task<ActionResult<EventDto>> Get([FromRoute] long id)
        {
            var @event = await _eventRepository.Get(id);
            if (@event == null)
                return NotFound();
            var result = _mapper.Map<EventDto>(@event);

            return Ok(result);
        }

        [HttpGet]
        [Route($"api/{Constants.ControllerShortcut}/{Constants.ActionShortcut}")]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            var result = _mapper.Map<List<EventDto>>(events);
            return Ok(result);
        }
    }
}