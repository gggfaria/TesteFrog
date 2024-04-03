namespace TesteFrogpay.Services.DTOs.Pessoa;

public class ViewPessoaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }
}