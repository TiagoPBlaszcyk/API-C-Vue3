using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Domain.IEvents;
using MS.Entities.Events;

namespace API.Controllers
{
    // TODO: Documentacao Swagger
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        private IEventsRepository _repository;
        public EventsController(IEventsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EventsVO>>> FindAll()
        {
            int userID = Int32.Parse(User.Identity.Name);
            var events = await _repository.FindAll(userID);
            return Ok(events);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EventsVO>> FindById(long id)
        {
            var events = await _repository.FindById(id);
            if (events == null) return BadRequest(new
            {
                error = $"Evento com {id} não encontrado"
            });
            return Ok(events);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EventsVO>> Create(EventsVO vo)
        {
            if (vo == null) return BadRequest();
            vo.PersonId =  Int16.Parse(User.Identity.Name);

            var events = await _repository.Create(vo);
            return Ok(events);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EventsVO>> Update(EventsVO vo)
        {
            if (vo == null || vo.Id == null) return BadRequest(new
            {
                error = $"Evento enviado sem Código Id :("
            });
            var events = await _repository.Update(vo);
            return Ok(events);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(long id)
        {
            if (id == null) return BadRequest();
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
