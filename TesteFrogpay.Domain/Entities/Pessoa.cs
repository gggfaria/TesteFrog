namespace TesteFrogpay.Domain.Entities;

public class Pessoa : BaseEntity
{
    public Pessoa(DateTime dataCriacao, string nome, string cpf, DateTime dataNascimento, bool estaAtivo) 
        : base( dataCriacao)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        EstaAtivo = estaAtivo;
    }

    public Pessoa() : base()
    {
        
    }

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }

}