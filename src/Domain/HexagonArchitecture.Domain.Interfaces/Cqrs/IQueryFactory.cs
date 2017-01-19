namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;

    #endregion

    public interface IQueryFactory
    {
        IQuery<T, IExpressionSpecification<T>> GetQuery<T>() where T : class, IHasId;

        IQuery<T, TSpecification> GetQuery<T, TSpecification>()
            where T : class, IHasId
            where TSpecification : ISpecification<T>;

        TQuery GetQuery<T, TSpecification, TQuery>()
            where T : class, IHasId
            where TSpecification : ISpecification<T>
            where TQuery : IQuery<T, TSpecification>;
    }
}