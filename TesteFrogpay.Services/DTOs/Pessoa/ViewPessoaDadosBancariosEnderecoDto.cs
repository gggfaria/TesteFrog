using TesteFrogpay.Services.DTOs.DadosBancarios;
using TesteFrogpay.Services.DTOs.Endereco;

namespace TesteFrogpay.Services.DTOs.Pessoa;

public class ViewPessoaDadosBancariosEnderecoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }
    public ViewDadosBancariosDto DadosBancarios { get; set; }
    public ViewEnderecoDto Endereco { get; set; }
}