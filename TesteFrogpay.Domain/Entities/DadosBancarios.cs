using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain;

public class DadosBancarios : BaseEntity
{

    public string Codigo { get;  set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DigitoConta { get;  set; }
   
}