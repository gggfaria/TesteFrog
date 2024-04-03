using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain.Interfaces;

public interface ILojaRepository
{
    Task<int?> Adicionar(Loja loja);
    Task<int?> Atualizar(Loja loja);
    Task<int?> Deletar(Guid id);
    Task<IEnumerable<Loja?>> SelecionarTodos();
    Task<Loja?> Selecionar(Guid id);
}