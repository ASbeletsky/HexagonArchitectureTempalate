using System;
using System.Linq;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
using HexagonArchitecture.Infrastructure.Interfaces;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs.GenericQueries
{
    public class GetByIdQuery<TKey, TEntity, TResult> : IQuery<TKey, TResult>
        where TKey : struct, IComparable, IComparable<TKey>, IEquatable<TKey>
        where TEntity : class, IEntity<TKey>
        where TResult : IEntity<TKey>
    {
        protected readonly IDataProvider DataProvider;

        protected readonly IProjector Projector;

        public GetByIdQuery([NotNull] IDataProvider linqProvider, [NotNull] IProjector projector)
        {
            if (linqProvider == null) throw new ArgumentNullException(nameof(linqProvider));
            if (projector == null) throw new ArgumentNullException(nameof(projector));

            DataProvider = linqProvider;
            Projector = projector;
        }

        public virtual TResult Ask(TKey specification)
        {
            return Projector.Project<TEntity, TResult>(DataProvider.Query<TEntity>().Where(x => specification.Equals(x.Id))).SingleOrDefault();
        }

    }
}