using Microsoft.AspNetCore.Mvc;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.Services;

namespace TesteFrogpay.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly AuthService _authService;
    
    public LoginController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginDto login)
    {
        if (! await _authService.Autenticar(login))
            return Unauthorized("Usuário ou Senha inválidos");

        var token = await _authService.GerarToken(login);
        return Ok(token);
    }
}