using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain;

public class DadosBancarios : BaseEntity
{
    public DadosBancarios(Guid id, DateTime dataCriacao, string codigo, string agencia, string conta, string digito) : base(dataCriacao)
    {
        Codigo = codigo;
        Agencia = agencia;
        Conta = conta;
        Digito = digito;
    }

    public DadosBancarios() : base()
    {
        
    }

    public string Codigo { get;  set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string Digito { get;  set; }
   
}