namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;
    using HexagonArchitecture.Domain.Interfaces.Paging;
    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public interface IEntityQuery<TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<TEntity> Where([NotNull] ISpecification<TEntity> specification);

        IEnumerable<TEntity> Include<TProperty>([NotNull] Expression<Func<TEntity, TProperty>> expression);

        [CanBeNull]
        TEntity FirstOrDefault(ISpecification<TEntity> specification);

        [NotNull]
        IPagedEnumerable<TEntity> Paged(int pageNumber, int take);

        long Count();
    }
}