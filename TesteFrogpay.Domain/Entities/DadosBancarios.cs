using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain;

public class DadosBancarios : BaseEntity
{
    public DadosBancarios(Guid id, DateTime dataCriacao, string codigo, string agencia, string conta, string digito) : base(id, dataCriacao)
    {
        Codigo = codigo;
        Agencia = agencia;
        Conta = conta;
        Digito = digito;
    }

    public string Codigo { get; private set; }
    public string Agencia { get; private set; }
    public string Conta { get; private set; }
    public string Digito { get; private set; }
   
}