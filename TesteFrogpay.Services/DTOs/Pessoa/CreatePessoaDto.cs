namespace TesteFrogpay.Services.DTOs.Pessoa;

public class CreatePessoaDto
{
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}