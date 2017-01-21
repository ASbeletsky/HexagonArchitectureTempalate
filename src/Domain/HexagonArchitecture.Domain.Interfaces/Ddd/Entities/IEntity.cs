namespace HexagonArchitecture.Domain.Interfaces.Ddd.Entities
{
    public interface IEntity : IHasId
    {
        bool IsNew { get; }
    }

    public interface IEntity<out TKey> : IEntity
    {
        new TKey Id { get; }
    }
}