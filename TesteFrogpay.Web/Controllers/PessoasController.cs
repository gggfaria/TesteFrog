using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Domain.Interfaces;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaRepository _pessoaRepository;
    
    public PessoasController(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var resultado = await _pessoaRepository.SelecionarTodos();
        if (resultado?.Count() == 0)
            return NoContent();
        return Ok(resultado);
    }
}