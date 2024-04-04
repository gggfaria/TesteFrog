using System.Data;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;
using Dapper;
using TesteFrogpay.Domain;

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

    public async Task<IEnumerable<Pessoa?>> SelecionarTodos(int numeroPagina, int tamanho)
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
                        OFFSET @Offset
                        FETCH NEXT @tamanho ROWS ONLY;
                    ", new
        {
            Offset = (numeroPagina-1) * tamanho,
            tamanho
        });
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
        var pessoa = await connection.QueryFirstOrDefaultAsync<Pessoa>(@"
                        select id, nome, cpf, data_nascimento as dataNascimento, ativo as estaAtivo, data_criacao as dataCriacao from tb_pessoa p
                        where @id = p.id;
                    ", new {id});
        if (pessoa != null)
        {
            await SelecionarEndereco(pessoa, connection);
            await SelecionarDadosBancarios(pessoa, connection);
        }
        
        connection.Close();
        return pessoa;
    }

    public async Task<Pessoa?> SelecionarPorNome(string nome)
    {
        var nomeLike = $"%{nome?.ToLower()}%"; 
        using  var connection = _dbContext.CreateConnection();
        var pessoa = await connection.QueryFirstOrDefaultAsync<Pessoa>(@"
                        select id, nome, cpf, data_nascimento as dataNascimento, ativo as estaAtivo, data_criacao as dataCriacao from tb_pessoa p
                        where lower(nome) like @nomeLike;
                    ", new {nomeLike});
        connection.Close();
        return pessoa;
    }
    
    private async Task SelecionarEndereco(Pessoa pessoa, IDbConnection connection)
    {
        pessoa.Endereco =  await connection.QueryFirstOrDefaultAsync<Endereco>(@"
                        select 
                           id, id_pessoa as pessoaId, uf, cidade, logradouro, bairro, numero, complemento,
                            data_criacao as dataCriacao
                        from tb_endereco
                        where id_pessoa = @id;
                    ", new {id = pessoa.Id});
    }
    
    private async Task SelecionarDadosBancarios(Pessoa pessoa, IDbConnection connection)
    {
        pessoa.DadosBancarios =  await connection.QueryFirstOrDefaultAsync<DadosBancarios>(@"
                       select 
                            id, 
                            id_pessoa as PessoaId,
                            codigo,
                            agencia, 
                            conta, 
                            digito_conta as DigitoConta,
                            data_criacao as dataCriacao
                        from tb_dados_bancarios
                        where @id = id_pessoa;
                    ", new {id = pessoa.Id});
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