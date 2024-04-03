using System.ComponentModel.DataAnnotations;

namespace TesteFrogpay.Services.DTOs.Loja;

public class CreateLojaDto
{
    [Required]
    public Guid PessoaId { get; set; }

    [Required]
    public string NomeFantasia { get; set; }
    
    [Required]
    public string RazaoSocial { get; set; }
    
    [Required]
    public string Cnpj { get; set; }
    
    [Required]
    public DateTime DataAbertura { get; set; }
}