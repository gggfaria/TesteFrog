namespace TesteFrogpay.Services.DTOs;

public class ListaPaginadaDto<TResposta>
{
    public ListaPaginadaDto(TResposta dadosPagina, PaginacaoDto parametrosPaginacao)
    {
        DadosPagina = dadosPagina;
        ParametrosPaginacao = parametrosPaginacao;
    }

    public TResposta DadosPagina { get; set; }
    public PaginacaoDto ParametrosPaginacao { get; set; }
}