using Dapper;
using TesteFrogpay.Domain;
using TesteFrogpay.Domain.Interfaces;

namespace TesteFrogpay.Infra.Repositories;

public class DadosBancariosRepository : IDadosBancariosRespository
{
    private readonly DbContext _dbContext;

    public DadosBancariosRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int?> Adicionar(DadosBancarios dadosBancarios)
    {
        using var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                insert into tb_dados_bancarios (id, id_pessoa, codigo, agencia, conta, digito_conta)
                values (@Id, @PessoaId, @Codigo, @Agencia, @Conta, @DigitoConta);
            ", dadosBancarios);
        return result;
    }

    public async Task<int?> Atualizar(DadosBancarios dadosBancarios)
    {
        using var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"
                    update tb_dados_bancarios
                    set id_pessoa = @PessoaId,
                        codigo = @Codigo,
                        agencia = @Agencia,
                        conta = @Conta,
                        digito_conta = @DigitoConta
                    where
                        id = @Id;
                ",
            dadosBancarios);
        return result;
    }

    public async Task<int?> Deletar(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var result = await connection.ExecuteAsync(@"  
                delete
                from tb_dados_bancarios
                where
                    id = @Id;
                ",
            new { id });
        return result;
    }

    public async Task<IEnumerable<DadosBancarios?>> SelecionarTodos()
    {
        using var connection = _dbContext.CreateConnection();
        var result = await connection.QueryAsync<DadosBancarios>(@"
                        select 
                            id, 
                            id_pessoa as PessoaId,
                            codigo,
                            agencia, 
                            conta, 
                            digito_conta as DigitoConta,
                            data_criacao as dataCriacao
                        from tb_dados_bancarios
                    ");
        return result;
    }

    public async Task<DadosBancarios?> Selecionar(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<DadosBancarios>(@"
                     select 
                            id, 
                            id_pessoa as PessoaId,
                            codigo,
                            agencia, 
                            conta, 
                            digito_conta as DigitoConta,
                            data_criacao as dataCriacao
                        from tb_dados_bancarios d
                        where id = @id;
                    ", new { id });
        return result;
    }
}