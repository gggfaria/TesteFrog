using TesteFrogpay.Domain.Entities;

namespace TesteFrogpay.Domain.Interfaces;

public interface IEnderecoRepository
{
    Task<int?> Adicionar(Endereco endereco);
    Task<int?> Atualizar(Endereco endereco);
    Task<int?> Deletar(Guid id);
    Task<IEnumerable<Endereco?>> SelecionarTodos();
    Task<Endereco?> Selecionar(Guid id);
    Task<IEnumerable<Endereco?>> SelecionarPessoaId(Guid id);
}