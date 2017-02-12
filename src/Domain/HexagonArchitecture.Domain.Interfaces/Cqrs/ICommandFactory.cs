using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    public interface ICommandFactory
    {
        TCommand GetCommand<TData, TCommand>() where TCommand : ICommandHandler<TData>;

        ICreateOrUpdateEntityCommand<TEntity> GetSaveCommand<TEntity>() where TEntity : class, IEntity;

        ICreateOrUpdateEntityCommand<TDto, TEntity> GetSaveCommand<TDto, TEntity>()
            where TEntity : class, IEntity
            where TDto : IHasId;

        IDeleteEntityCommand<TKey, TEntity> GetDeleteCommand<TKey, TEntity>() where TEntity : class, IEntity<TKey>;
    }
}