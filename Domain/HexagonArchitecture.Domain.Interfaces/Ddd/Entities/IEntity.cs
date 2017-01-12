namespace HexagonArchitecture.Domain.Interfaces.Ddd.Entities
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<out TKey> : IEntity
    {
        new TKey Id { get; }
    }
}