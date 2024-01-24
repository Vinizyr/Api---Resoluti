using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaResoluti.App.Features.Login;

namespace ProvaResoluti.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;
        public LoginController(LoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {

            if (ModelState.IsValid)
            {
                var result = await _loginHandler.Handle(command);
                return Ok(result);
            }
            else
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();
                return BadRequest(erros);
            }
        }
    }
}
