using Microsoft.AspNetCore.Mvc;
using ProvaResoluti.App.Features.PessoaFeature;
using ProvaResoluti.App.Features.PessoaFeature.Commands;
using ProvaResoluti.Domain.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProvaResoluti.Controllers
{
    [Route("[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly PessoaFisicaHandler _pessoaHandler;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaController(PessoaFisicaHandler pessoaHandler, IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaHandler = pessoaHandler;
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pessoaFisicaRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("/{PessoaId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int PessoaId)
        {
            var result = await _pessoaFisicaRepository.GetById(PessoaId);
            return Ok(result);
        }

        [HttpPost]
        [Route("/cadastro")]
        public async Task<IActionResult> PostPessoa([FromBody] PessoaFisicaCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _pessoaHandler.Handle(command);
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

        [HttpPut]
        [Route("{PessoaId:int}")]
        public async Task<IActionResult> PutPessoa(int PessoaId, [FromBody] UpdatePessoaFisicaCommand command)
        {
            command.PessoaId = PessoaId;
            command.PessoaLogada = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _pessoaHandler.Handle(command);
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

        [HttpDelete]
        [Route("{PessoaId:int}")]
        public async Task<IActionResult> DeletePessoa(DeletePessoaFisicaCommand command)
        {
            command.PessoaLogada = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _pessoaHandler.Handle(command);
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
