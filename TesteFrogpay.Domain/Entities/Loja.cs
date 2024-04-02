namespace TesteFrogpay.Domain.Entities;

public class Loja : BaseEntity
{
    public Loja(Guid id, DateTime dataCriacao, Guid pessoaId, string nomeFantasia, string razaoSocial,
        DateTime dataAbertura) : base(dataCriacao)
    {
        PessoaId = pessoaId;
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        DataAbertura = dataAbertura;
    }

    public Loja() : base()
    {
    }

    public Guid PessoaId { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public DateTime DataAbertura { get; set; }
}