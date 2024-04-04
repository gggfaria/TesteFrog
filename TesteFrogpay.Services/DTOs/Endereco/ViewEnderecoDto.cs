namespace TesteFrogpay.Services.DTOs.Endereco;

public class ViewEnderecoDto
{
    public Guid PessoaId { get; set; }

    public Guid Id { get; set; }

    public string UF { get; set; }

    public string Cidade { get; set; }

    public string Bairro { get; set; }

    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Complemento { get; set; }
    public DateTime DataCriacao { get; set; }
}