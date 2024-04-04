using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Services.DTOs.Endereco;
using TesteFrogpay.Services.Services;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "PADRAO,ADMIN")]
public class EnderecoController : Controller
{
    private readonly EnderecoService _enderecoService;

    public EnderecoController(EnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var resultado = await _enderecoService.SelecionarTodos();
        return StatusCode(resultado.Status, resultado);
    }
    
    
    [HttpGet("pessoanome")]
    public async Task<ActionResult> Get([FromQuery] string pessoaNome)
    {
        var resultado = await _enderecoService.SelecionarEnderecoPorNomePessoa(pessoaNome);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var resultado = await _enderecoService.SelecionarPorId(id);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Post([FromBody] CreateEnderecoDto dto)
    {
        var resultado = await _enderecoService.Adicionar(dto);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Put([FromBody] UpdateEnderecoDto dto)
    {
        var resultado = await _enderecoService.Atualizar(dto);
        return StatusCode(resultado.Status, resultado);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var resultado = await _enderecoService.Deletar(id);
        return StatusCode(resultado.Status, resultado);
    }
}