using System.Text.RegularExpressions;
using API.Data.ValueObjects;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _repository;
        public PersonController(IPersonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PersonVO>>> FindAll()
        {
            var persons = await _repository.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<PersonVO>> FindById(long id)
        {
            var person = await _repository.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<PersonVO>> Create(PersonVO vo)
        {
            if (vo == null) return BadRequest();

            var person = await _repository.Create(vo);
            return Ok(person);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<PersonVO>> Update(PersonVO vo)
        {
            if (vo == null) return BadRequest();
            var person = await _repository.Update(vo);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(long id)
        {
            if (id == null) return BadRequest();
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        
    }
}
