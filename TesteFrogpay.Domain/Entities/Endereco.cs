namespace TesteFrogpay.Domain.Entities;

public class Endereco : BaseEntity
{
    public Endereco() : base()
    {
    }

    public Guid PessoaId { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }


    private string _uf;

    public string UF
    {
        get { return _uf; }
        set
        {
            if (_siglasEstadosDoBrasil.Contains(value?.ToUpper() ?? ""))
                _uf = value;
            else
            throw new ArgumentException("UF inválida");
        }
    }


    List<string> _siglasEstadosDoBrasil = new List<string>
    {
        "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
    };
}