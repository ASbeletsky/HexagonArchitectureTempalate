using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{

    public interface ICreateOrUpdateEntityCommand<in TEntity> : ICommandHandler<TEntity, object>
        where TEntity : IHasId
    {

    }

    public interface ICreateOrUpdateEntityCommand<in TDto, TEntity> : ICommandHandler<TDto, object>
        where TEntity : IHasId
    {

    }
}