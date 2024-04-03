using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Services.DTOs.Pessoa;
using TesteFrogpay.Services.Services;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "PADRAO,ADMIN")]
public class PessoasController : ControllerBase
{
    private readonly PessoaService _pessoaService;

    public PessoasController(PessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var resultado = await _pessoaService.SelecionarTodos();
        if (resultado?.Count() == 0)
            return NoContent();
        return Ok(resultado);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var resultado = await _pessoaService.SelecionarPorId(id);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreatePessoaDto dto)
    {
        var resultado = await _pessoaService.Adicionar(dto);
        return StatusCode(resultado.Status, resultado);
    }
}