namespace TesteFrogpay.Domain.Entities;

public class Pessoa : BaseEntity
{
    public Pessoa(Guid id, DateTime dataCriacao, string nome, string cpf, DateTime dataNascimento, bool estaAtivo) 
        : base(id, dataCriacao)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        EstaAtivo = estaAtivo;
    }

    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public bool EstaAtivo { get; private set; }

}