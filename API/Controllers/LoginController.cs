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
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginVO model)
        {
            Person person = await _repository.FindByName(model.Name);
            if (person == null || model.Senha != person.Senha) return NotFound("Login ou senha incorretos (Login:admin, Senha:admin)!");

            var token = TokenService.GenerateToken(person);

            return new
            {
                user = model,
                token = token
            };
        }
    }
}
