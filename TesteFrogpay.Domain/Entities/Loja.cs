namespace TesteFrogpay.Domain.Entities;

public class Loja : BaseEntity
{
    public Loja(Guid id, DateTime dataCriacao, Guid pessoaId, string nomeFantasia, string razaoSocial, DateTime dataAbertura) : base(id, dataCriacao)
    {
        PessoaId = pessoaId;
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        DataAbertura = dataAbertura;
    }

    public Guid PessoaId { get; private set; }
    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public DateTime DataAbertura { get; private set; }
}