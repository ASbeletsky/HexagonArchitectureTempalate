using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{

    public interface ICreateOrUpdateEntityCommand<in TEntity> : ICommandHandler<TEntity, object>
        where TEntity : IEntity
    {

    }

    public interface ICreateOrUpdateEntityCommand<in TDto, TEntity> : ICommandHandler<TDto, object>
        where TDto : IHasId
        where TEntity : IEntity
    {
        TKey Execute<TKey>(TDto dto);
    }
}