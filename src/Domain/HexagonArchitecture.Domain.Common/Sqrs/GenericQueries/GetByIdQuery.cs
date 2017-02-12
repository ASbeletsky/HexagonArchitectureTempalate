namespace HexagonArchitecture.Domain.Common.Sqrs.GenericQueries
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Domain.Common.Specifications;
    using JetBrains.Annotations;

    #endregion

    public class GetByIdQuery<TKey, TEntity> : IQuery<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly IQueryableDataSource DataSource;

        public GetByIdQuery([NotNull] IQueryableDataSource dataSource)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            DataSource = dataSource;
        }

        public virtual TEntity Ask(TKey id)
        {

            return DataSource
                .Query<TEntity>()
                .FirstOrDefault(new IdSpecification<TKey, TEntity>(id).Expression);
        }
    }

    public class GetByIdQuery<TKey, TEntity, TDto> : IQuery<TKey, TDto>  where TEntity : class, IEntity<TKey>
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

        public virtual TDto Ask(TKey id)
        {
            var entities = DataSource.Query<TEntity>().Where(new IdSpecification<TKey, TEntity>(id).Expression);
            return Projector.Project<TEntity, TDto>(entities).FirstOrDefault();
        }
    }
}