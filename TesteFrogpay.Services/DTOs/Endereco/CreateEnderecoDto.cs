using System.ComponentModel.DataAnnotations;

namespace TesteFrogpay.Services.DTOs.Endereco;

public class CreateEnderecoDto
{
    [Required]
    public Guid PessoaId { get; set; }
    [Required]
    public string UF { get; set; }
    [Required]
    public string Cidade { get; set; }
    [Required]
    public string Bairro { get; set; }
    [Required]
    public string Logradouro { get; set; }
    [Required]
    public string Numero { get; set; }

    public string Complemento { get; set; }
}