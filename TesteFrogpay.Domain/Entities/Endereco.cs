namespace TesteFrogpay.Domain.Entities;

public class Endereco : BaseEntity
{
    public Endereco(Guid id, DateTime dataCriacao, string uf, string cidade, string bairro, string logradouro,
        string numero, string complemento) : base(dataCriacao)
    {
        UF = uf;
        Cidade = cidade;
        Bairro = bairro;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
    }

    public Endereco() : base()
    {
    }

    public string UF { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
}