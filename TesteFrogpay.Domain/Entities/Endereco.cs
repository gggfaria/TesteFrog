namespace TesteFrogpay.Domain.Entities;

public class Endereco : BaseEntity
{
 

    public Endereco() : base()
    {
    }

    public Guid PessoaId { get; set; }
    public string UF { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
}