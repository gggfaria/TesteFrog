namespace TesteFrogpay.Domain.Entities;

public class Pessoa : BaseEntity
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }

    public Pessoa(Guid id, DateTime dataCriacao) : base(id, dataCriacao)
    {
    }
}