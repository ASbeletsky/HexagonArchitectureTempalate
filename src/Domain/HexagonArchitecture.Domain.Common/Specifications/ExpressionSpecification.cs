using System;
using System.Linq.Expressions;
using HexagonArchitecture.Domain.Common.Extensions;
using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Specifications
{
    #region Using

    #endregion

    [PublicAPI]
    public class ExpressionSpecification<T> : ISpecification<T>
    {
        public virtual Expression<Func<T, bool>> Expression { get; private set; }

        private Func<T, bool> Func => Expression.AsFunc();

        public ExpressionSpecification([NotNull] Expression<Func<T, bool>> expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Expression = expression;
        }

        public bool IsSatisfiedBy(T o)
        {
            return Func(o);
        }
    }
}