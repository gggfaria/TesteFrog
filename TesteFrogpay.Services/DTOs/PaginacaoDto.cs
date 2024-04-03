using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteFrogpay.Services.DTOs;

public class PaginacaoDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Intervalo inválido do número da página")]
    public int NumeroPagina { get; set; }

    [Range(0, 100, ErrorMessage = "Intervalo inválido da quantidade de itens por página")]
    public int TamanhoPorPagina { get; set; }

}