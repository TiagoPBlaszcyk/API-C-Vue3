using System.Text.RegularExpressions;
using API.Data.ValueObjects;
using API.Repository;
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
        public async Task<ActionResult<IEnumerable<PersonVO>>> FindAll()
        {
            System.Threading.Thread.Sleep(2000);
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
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

            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<PersonVO>> Update(PersonVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id == null) return BadRequest();
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        
    }
}
