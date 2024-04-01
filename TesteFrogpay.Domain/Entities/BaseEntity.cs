namespace TesteFrogpay.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id, DateTime dataCriacao)
    {
        Id = id;
        DataCriacao = dataCriacao;
    }

    public Guid Id { get; private set; }
    public DateTime DataCriacao { get; private set; }

}