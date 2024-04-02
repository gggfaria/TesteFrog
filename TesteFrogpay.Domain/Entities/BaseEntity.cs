namespace TesteFrogpay.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(DateTime dataCriacao)
    {
        Id = Guid.NewGuid();
        DataCriacao = dataCriacao;
    }

    public BaseEntity()
    {
        
    }

    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }

}