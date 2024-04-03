namespace TesteFrogpay.Domain.Entities;

public class Loja : BaseEntity
{
    public Loja() : base()
    {
    }

    public Guid PessoaId { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataAbertura { get; set; }
}