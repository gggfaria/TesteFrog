namespace TesteFrogpay.Domain.Entities;

public abstract class BaseEntity
{
    public BaseEntity()
    {
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataCriacao { get; set; }
}