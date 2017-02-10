namespace HexagonArchitecture.Domain.Interfaces.Ddd.Entities
{
    public interface IAggregateRoot : IEntity
    {

    }

    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {

    }
}