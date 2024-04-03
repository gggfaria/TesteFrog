namespace TesteFrogpay.Services.DTOs.DadosBancarios;

public class ViewDadosBancariosDto
{
    public Guid PessoaId { get; set; }
    public Guid Id { get; set; }
    public string Codigo { get;  set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DigitoConta { get;  set; }
    public DateTime DataCriacao { get; set; }
}