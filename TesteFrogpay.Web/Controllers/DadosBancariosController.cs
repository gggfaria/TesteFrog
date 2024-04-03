using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Services.DTOs.DadosBancarios;
using TesteFrogpay.Services.Services;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "PADRAO,ADMIN")]
public class DadosBancariosController : Controller
{
 
    private readonly DadosBancariosService _dadosBancariosService;

    public DadosBancariosController(DadosBancariosService dadosBancariosService)
    {
        _dadosBancariosService = dadosBancariosService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var resultado = await _dadosBancariosService.SelecionarTodos();
        return StatusCode(resultado.Status, resultado);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var resultado = await _dadosBancariosService.SelecionarPorId(id);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Post([FromBody] CreateDadosBancariosDto dto)
    {
        var resultado = await _dadosBancariosService.Adicionar(dto);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Put([FromBody] UpdateDadosBancariosDto dto)
    {
        var resultado = await _dadosBancariosService.Atualizar(dto);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var resultado = await _dadosBancariosService.Deletar(id);
        return StatusCode(resultado.Status, resultado);
    }
}