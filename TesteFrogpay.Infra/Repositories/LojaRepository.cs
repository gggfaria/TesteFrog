using Dapper;
using TesteFrogpay.Domain.Entities;
using TesteFrogpay.Domain.Interfaces;

namespace TesteFrogpay.Infra.Repositories;

public class LojaRepository : ILojaRepository
{
    private readonly DbContext _dbContext;
    
    public LojaRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int?> Adicionar(Loja loja)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                insert into tb_loja (id, pessoa_id, nome_fantasia, razao_social, cnpj, data_abertura)
                values (@Id, @PessoaId, @NomeFantasia, @RazaoSocial, @Cnpj, @DataAbertura);
            ", loja);
        return result;
    }
    
    public async Task<int?> Atualizar(Loja loja)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                    update tb_loja
                    set pessoa_id = @PessoaId,
                        nome_fantasia = @NomeFantasia,
                        razao_social = @RazaoSocial,
                        cnpj = @Cnpj,
                        data_abertura = @DataAbertura
                    where
                        id = @Id;
                ",
            loja);
        return result;
    }
    
    public async Task<int?> Deletar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"  
                delete
                from tb_loja
                where
                    id = @Id;
                ",
            new {id});
        return result;
    }

    public async Task<IEnumerable<Loja?>> SelecionarTodos()
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<Loja>(@"
                        select 
                            id, 
                            pessoa_id as PessoaId,
                            nome_fantasia as NomeFantasia,
                            razao_social as RazaoSocial,
                            cnpj,
                            data_abertura as DataAbertura,
                            data_criacao as dataCriacao
                        from tb_loja
                    ");
        return result;
    }

    public async Task<Loja?> Selecionar(Guid id)
    {
        using  var connection = _dbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Loja>(@"
                        select 
                            id, 
                            pessoa_id as PessoaId,
                            nome_fantasia as NomeFantasia,
                            razao_social as RazaoSocial,
                            cnpj,
                            data_abertura as DataAbertura,
                            data_criacao as dataCriacao
                        from tb_loja l
                        where @id = l.id;
                    ", new {id});
        return result;
    }
     
}