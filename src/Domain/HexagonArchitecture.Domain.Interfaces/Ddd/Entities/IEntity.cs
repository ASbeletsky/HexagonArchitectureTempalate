namespace HexagonArchitecture.Domain.Interfaces.Ddd.Entities
{
    public interface IEntity<out TKey> : IHasId
    {
        new TKey Id { get; }
    }
}