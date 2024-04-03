using System.ComponentModel.DataAnnotations;

namespace TesteFrogpay.Services.DTOs.Pessoa;

public class UpdatePessoaDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public string Permissao { get; set; }
}