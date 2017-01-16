using HexagonArchitecture.Domain.Interfaces.Data;

namespace HexagonArchitecture.Services.Common.Sqrs.GenericQueries
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion

    public class GetByIdQuery<TKey, TEntity, TResult> : IQuery<TKey, TResult>  where TEntity : class, IEntity<TKey>
    {
        protected readonly ILinqProvider LinqProvider;

        protected readonly IProjector Projector;

        public GetByIdQuery([NotNull] ILinqProvider linqProvider, [NotNull] IProjector projector)
        {
            if (linqProvider == null) throw new ArgumentNullException(nameof(linqProvider));
            if (projector == null) throw new ArgumentNullException(nameof(projector));

            LinqProvider = linqProvider;
            Projector = projector;
        }

        public virtual TResult Ask(TKey id)
        {
            return Projector.Project<TEntity, TResult>(LinqProvider.Query<TEntity>().Where(entity => id.Equals(entity.Id))).SingleOrDefault();
        }

    }
}