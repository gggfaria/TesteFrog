using TesteFrogpay.Services.DTOs.Pessoa;

namespace TesteFrogpay.Services.DTOs.Endereco;

public class ViewEnderecoPessoaDto
{
    public ViewPessoaDto Pessoa { get; set; }

    public IEnumerable<ViewEnderecoDto> Enderecos { get; set; }
   
}