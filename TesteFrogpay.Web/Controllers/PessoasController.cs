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
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Post([FromBody] CreatePessoaDto dto)
    {
        var resultado = await _pessoaService.Adicionar(dto);
        return StatusCode(resultado.Status, resultado);
    }
    
    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Put([FromBody] UpdatePessoaDto dto)
    {
        var resultado = await _pessoaService.Atualizar(dto);
        return StatusCode(resultado.Status, resultado);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var resultado = await _pessoaService.Deletar(id);
        return StatusCode(resultado.Status, resultado);
    }
}