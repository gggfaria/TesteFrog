using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Services.DTOs.Loja;
using TesteFrogpay.Services.Services;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "PADRAO,ADMIN")]
public class LojaController : ControllerBase
{
    private readonly LojaService _lojaService;

    public LojaController(LojaService lojaService)
    {
        _lojaService = lojaService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var resultado = await _lojaService.SelecionarTodos();
        return StatusCode(resultado.Status, resultado);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var resultado = await _lojaService.SelecionarPorId(id);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Post([FromBody] CreateLojaDto  dto)
    {
        var resultado = await _lojaService.Adicionar(dto);
        return StatusCode(resultado.Status, resultado);
    }
    
    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Put([FromBody] UpdateLojaDto  dto)
    {
        var resultado = await _lojaService.Atualizar(dto);
        return StatusCode(resultado.Status, resultado);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var resultado = await _lojaService.Deletar(id);
        return StatusCode(resultado.Status, resultado);
    }
}