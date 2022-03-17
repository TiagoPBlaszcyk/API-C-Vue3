using API.Data.ValueObjects;
using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private IPersonRepository _repository;
        public LoginController(IPersonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateAsync([FromBody] LoginVO model)
        {
            Person person = await _repository.FindByName(model.Name);
            if (person == null || model.Senha != person.Senha) return BadRequest();

            var token = TokenService.GenerateToken(person);

            return Ok(new
            {
                user = model,
                token = token
            });
        }

        [HttpPost]
        [Route("Cadastro")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> RegisterAsync([FromBody] PersonVO model)
        {
            if (model == null) return BadRequest();
            PersonVO person = await _repository.Create(model);

            return Ok(person);
        }
    }
}
