namespace TesteFrogpay.Services.DTOs.Loja;

public class ViewLojaDto
{
    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataCriacao { get; set; }
}