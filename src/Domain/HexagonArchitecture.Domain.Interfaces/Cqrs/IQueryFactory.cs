namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;

    #endregion

    public interface IQueryFactory
    {
        TQuery GetQuery<TResult, TQuery>() where TQuery : IQuery<TResult>;

        TQuery GetQuery<TData, TResult, TQuery>() where TQuery : IQuery<TData, TResult>;

        IEntityQuery<TEntity> QueryEntity<TEntity>()
            where TEntity : class, IEntity;

    }
}