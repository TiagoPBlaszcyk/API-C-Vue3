using API.Data.ValueObjects;
using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
            var events = await _repository.FindAll();
            return Ok(events);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EventsVO>> FindById(long id)
        {
            var events = await _repository.FindById(id);
            if (events == null) return NotFound();
            return Ok(events);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EventsVO>> Create(EventsVO vo)
        {
            if(User.Identity.Name  == null)
                return BadRequest();
            vo.PersonId =  Int16.Parse(User.Identity.Name);
            if (vo == null) return BadRequest();

            var events = await _repository.Create(vo);
            return Ok(events);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EventsVO>> Update(EventsVO vo)
        {
            if (vo == null) return BadRequest();
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
