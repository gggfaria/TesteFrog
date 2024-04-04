using Dapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;

namespace TesteFrogpay.Infra.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly DbContext _dbContext;
    
    public EnderecoRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int?> Adicionar(Endereco endereco)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                insert into tb_endereco (id, id_pessoa, uf, cidade, logradouro, bairro, numero, complemento)
                values (@Id, @PessoaId, @UF, @Cidade, @Logradouro, @Bairro, @Numero, @Complemento);
            ", endereco);
        connection.Close();
        return result;
    }
    
    public async Task<int?> Atualizar(Endereco endereco)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                    update tb_endereco
                    set pessoa_id = @PessoaId,
                        uf = @UF,
                        cidade = @Cidade,
                        logradouro = @Logradouro,
                        bairro = @Bairro,
                        numero = @Numero,
                        complemento = @Comlemento
                    where
                        id = @Id;
                ",
            endereco);
        connection.Close();
        return result;
    }
    
    public async Task<int?> Deletar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"  
                delete
                from tb_endereco
                where
                    id = @Id;
                ",
            new {id});
        connection.Close();
        return result;
    }

    public async Task<IEnumerable<Endereco?>> SelecionarTodos()
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<Endereco>(@"
                        select 
                           id, id_pessoa as pessoaId, uf, cidade, logradouro, bairro, numero, complemento,
                            data_criacao as dataCriacao
                        from tb_endereco
                    ");
        connection.Close();
        return result;
    }

    public async Task<Endereco?> Selecionar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Endereco>(@"
                        select 
                           id, id_pessoa as pessoaId, uf, cidade, logradouro, bairro, numero, complemento,
                            data_criacao as dataCriacao
                        from tb_endereco
                        where id = @id;
                    ", new {id});
        connection.Close();
        return result;
    }

    public async Task<IEnumerable<Endereco?>> SelecionarPessoaId(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<Endereco>(@"
                        select 
                           id, id_pessoa as pessoaId, uf, cidade, logradouro, bairro, numero, complemento,
                            data_criacao as dataCriacao
                        from tb_endereco
                        where id_pessoa = @id;
                    ", new {id});
        connection.Close();
        return result;
    }
}