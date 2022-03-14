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
            ///^
            //(?=.*\d)              // deve conter ao menos um dígito
            //(?=.*[a-z])           // deve conter ao menos uma letra minúscula
            //(?=.*[A-Z])           // deve conter ao menos uma letra maiúscula
            //(?=.*[$*&@#])         // deve conter ao menos um caractere especial
            //[0-9a-zA-Z$*&@#]{8,}  // deve conter ao menos 8 dos caracteres mencionados
            //$/  [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
            var validate = @"^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$";
            Regex rg = new Regex(validate);  
            MatchCollection matched = rg.Matches(vo.Senha); 
            Console.WriteLine(matched);

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
