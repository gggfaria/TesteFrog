using TesteFrogpay.Domain.Entities.Enums;

namespace TesteFrogpay.Domain.Entities;

public class Pessoa : BaseEntity
{
    public static readonly HashSet<string> PERMISSOES = new HashSet<string> { "ADMIN", "PADRAO" };

    public Pessoa() : base()
    {
    }

    public string Usuario { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }

    private string _permissao;

    public string Permissao
    {
        get { return _permissao; }
        set
        {
            if (PERMISSOES.Contains(value))
                _permissao = value;
            else
                throw new ArgumentException("Permissao não é válida");
        }
    }
}