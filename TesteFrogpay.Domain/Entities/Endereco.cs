namespace TesteFrogpay.Domain.Entities;

public class Endereco : BaseEntity
{
    public Endereco(Guid id, DateTime dataCriacao, string uf, string cidade, string bairro, string logradouro, string numero, string complemento) : base(id, dataCriacao)
    {
        UF = uf;
        Cidade = cidade;
        Bairro = bairro;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
    }

    public string UF { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
}