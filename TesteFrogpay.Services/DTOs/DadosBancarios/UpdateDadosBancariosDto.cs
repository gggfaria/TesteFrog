using System.ComponentModel.DataAnnotations;

namespace TesteFrogpay.Services.DTOs.DadosBancarios;

public class UpdateDadosBancariosDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid PessoaId { get; set; }
    [Required]
    public string Codigo { get;  set; }
    [Required]
    public string Agencia { get; set; }
    [Required]
    public string Conta { get; set; }
    [Required]
    public string DigitoConta { get;  set; }

}