using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TesteFrogpay.Domain;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Services.DTOs;
using TesteFrogpay.Services.Utils;

namespace TesteFrogpay.Services.Services;

public class AuthService
{
    private readonly IPessoaRepository _pessoaRepository;

    private readonly string? _chaveJwt;

    public AuthService(IPessoaRepository pessoaRepository, JwtInjection jwtInjection)
    {
        _pessoaRepository = pessoaRepository;

        _chaveJwt = jwtInjection.Token;
    }

    public async Task<bool> Autenticar(LoginDto login)
    {
        var usuario = await _pessoaRepository.SelecionarLogin(login.Usuario);
        return usuario?.Senha == login.Senha.CriptografarSenha();
    }

    public async Task<string> GerarToken(LoginDto loginDTO)
    {
        var taskLogin = _pessoaRepository.SelecionarLogin(loginDTO.Usuario);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_chaveJwt);

        var usuario = await taskLogin;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim("Nome", usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.Permissao.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}