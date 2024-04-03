namespace TesteFrogpay.Domain.Interfaces;

public interface IDadosBancariosRespository
{
    Task<int?> Adicionar(DadosBancarios dadosBancarios);

    Task<int?> Atualizar(DadosBancarios dadosBancarios);

    Task<int?> Deletar(Guid id);

    Task<IEnumerable<DadosBancarios?>> SelecionarTodos();
    
    Task<DadosBancarios?> Selecionar(Guid id);
}