using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<int?> Adicionar(Pessoa pessoa);
    Task<IEnumerable<Pessoa?>> SelecionarTodos();
    Task<Pessoa> Selecionar(Guid id);
    Task<Pessoa> SelecionarLogin(string usuario);

}