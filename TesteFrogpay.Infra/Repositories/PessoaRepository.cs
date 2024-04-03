using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using Dapper;

namespace TesteFrogpay.Infra.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly DbContext _dbContext;
    
    public PessoaRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> Adicionar(Pessoa pessoa)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"insert into tb_pessoa (id, nome, cpf, data_nascimento, ativo, usuario, senha) values (@Id, @Nome, @Cpf, @DataNascimento, @EstaAtivo, @Usuario, @Senha);",
            pessoa);
        connection.Close();
        return result;
    }
    
    public async Task<int?> Atualizar(Pessoa pessoa)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                    update tb_pessoa
                    set nome = @Nome,
                        cpf = @Cpf,
                        data_nascimento = @DataNascimento,
                        ativo = @EstaAtivo,
                        permissao = @Permissao
                    where
                        id = @Id;
                ",
            pessoa);
        connection.Close();
        return result;
    }
    
    public async Task<int?> Deletar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"  
                delete
                from tb_pessoa
                where
                    id = @Id;
                ",
            new {id});
        connection.Close();
        return result;
    }

    public async Task<IEnumerable<Pessoa?>> SelecionarTodos()
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<Pessoa>(@"
                        select id, 
                               nome, 
                               cpf, 
                               data_nascimento as dataNascimento,
                               ativo as estaAtivo, 
                               data_criacao as dataCriacao
                        from tb_pessoa
                    ");
        connection.Close();
        return result;
    }

    public async Task<Pessoa?> Selecionar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Pessoa>(@"
                        select id, nome, cpf, data_nascimento as dataNascimento, ativo as estaAtivo, data_criacao as dataCriacao from tb_pessoa p
                        where @id = p.id;
                    ", new {id});
        connection.Close();
        return result;
    }
    
    public async Task<Pessoa> SelecionarLogin(string usuario)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Pessoa>(@"
                        select id, 
                               nome,
                               cpf, 
                               data_nascimento as dataNascimento,
                               ativo as estaAtivo, 
                               data_criacao as dataCriacao,
                               usuario, 
                               senha, 
                               permissao
                        from tb_pessoa p
                        where @usuario = p.usuario;
                    ", new {usuario});
        connection.Close();
        return result;
    }
    
    
}