namespace HexagonArchitecture.Services.Common.Sqrs.GenericQueries
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using JetBrains.Annotations;

    #endregion

    public class GetByIdQuery<TKey, TEntity, TResult> : IQuery<TKey, TResult>  where TEntity : class, IEntity<TKey>
    {
        protected readonly IQueryableDataSource DataSource;
        protected readonly IProjector Projector;

        public GetByIdQuery([NotNull] IQueryableDataSource dataSource, [NotNull] IProjector projector)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (projector == null) throw new ArgumentNullException(nameof(projector));

            DataSource = dataSource;
            Projector = projector;
        }

        public virtual TResult Ask(TKey id)
        {
            var entities = DataSource.Query<TEntity>().Where(entity => entity.Id.Equals(id));
            return Projector.Project<TEntity, TResult>(entities).FirstOrDefault();
        }

    }
}