using System.ComponentModel.DataAnnotations;

namespace TesteFrogpay.Services.DTOs.Loja;

public class UpdateLojaDto
{
    [Required]
    public Guid Id { get; set; }
    
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