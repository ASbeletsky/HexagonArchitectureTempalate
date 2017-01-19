using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    public interface ICommandFactory
    {
        TCommand GetCommand<TData, TCommand>() where TCommand : ICommandHandler<TData>;

        ICreateOrUpdateEntityCommand<TEntity> GetCreateCommand<TEntity>() where TEntity : class, IHasId;

        ICreateOrUpdateEntityCommand<TDto, TEntity> GetCreateCommand<TDto, TEntity>() where TEntity : class, IHasId;

        IDeleteEntityCommand<TKey, TEntity> GetDeleteCommand<TKey, TEntity>() where TEntity : class, IEntity<TKey>;
    }
}