namespace HexagonArchitecture.Domain.Interfaces.Ddd.Specifications
{
    #region Using

    using System;
    using System.Linq.Expressions;

    #endregion

    public interface IExpressionSpecification<T> : ISpecification<T>
    {
        Expression<Func<T, bool>> Expression { get; }
    }
}