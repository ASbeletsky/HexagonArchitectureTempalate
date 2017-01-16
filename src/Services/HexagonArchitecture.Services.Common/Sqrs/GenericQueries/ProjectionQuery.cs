using HexagonArchitecture.Domain.Interfaces.Data;

namespace HexagonArchitecture.Services.Common.Sqrs.GenericQueries
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Services.Common.Extensions;
    using HexagonArchitecture.Services.Common.Specifications;
    using JetBrains.Annotations;

    #endregion
    
    public class ProjectionQuery<TSpecification, TSource, TDest>: IQuery<TSpecification, IEnumerable<TDest>> , IQuery<TSpecification, int>
        where TSource : class, IEntity
        where TDest : class
    {
        protected readonly ILinqProvider LinqProvider;
        protected readonly IProjector Projector;

        private static readonly Type[] SpecTypes = {
            typeof(ILinqSorting<TSource>),
            typeof(ILinqSorting<TDest>),
            typeof(ILinqSpecification<TSource>),
            typeof(ILinqSpecification<TDest>),
            typeof(Expression<Func<TSource, bool>>),
            typeof(Expression<Func<TDest, bool>>),
            typeof(ExpressionSpecification<TSource>),
            typeof(ExpressionSpecification<TDest>)
        };

        private static string ErrorMessage => SpecTypes.Select(x => x.ToString()).Aggregate((c, n) => $"{c}\n{n}");

        public ProjectionQuery([NotNull] ILinqProvider linqProviderProvider, [NotNull] IProjector projector)
        {
            if (linqProviderProvider == null) throw new ArgumentNullException(nameof(linqProviderProvider));
            if (projector == null) throw new ArgumentNullException(nameof(projector));

            LinqProvider = linqProviderProvider;
            Projector = projector;
        }

        protected virtual IQueryable<TDest> GetQueryable(TSpecification spec)
        {
            return LinqProvider
                .Query<TSource>()
                .MaybeWhere(spec)
                .MaybeSort(spec)
                .Project<TSource, TDest>(Projector)
                .MaybeWhere(spec)
                .MaybeSort(spec);
        }

        public virtual IEnumerable<TDest> Ask(TSpecification specification) => GetQueryable(specification).ToArray();

        int IQuery<TSpecification, int>.Ask(TSpecification specification) => GetQueryable(specification).Count();
    }
}