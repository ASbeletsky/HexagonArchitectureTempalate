using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace HexagonArchitecture.Infrastructure.Interfaces
{
    /// <summary>
    /// Sort order enumeration
    /// </summary>
    [PublicAPI]
    public enum SortOrder
    {
        [PublicAPI] Asc = 1,
        [PublicAPI] Desc = 2
    }

    [PublicAPI]
    public class Sorting<TEntity, TKey> where TEntity: class
    {
        public Expression<Func<TEntity, TKey>> Expression { get; private set; }

        public SortOrder SortOrder { get; private set; }

        public Sorting([NotNull] Expression<Func<TEntity, TKey>> expression, SortOrder sortOrder = SortOrder.Asc)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Expression = expression;
            SortOrder = sortOrder;
        }
    }
}