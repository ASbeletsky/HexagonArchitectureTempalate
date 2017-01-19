using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    public interface IDeleteEntityCommand<in TKey, TEntity> :  ICommandHandler<TKey> where TEntity : class, IEntity<TKey>
    {

    }
}