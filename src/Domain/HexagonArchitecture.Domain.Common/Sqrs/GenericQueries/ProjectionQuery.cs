﻿namespace HexagonArchitecture.Domain.Common.Sqrs.GenericQueries
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using HexagonArchitecture.Domain.Common.Extensions;
    using HexagonArchitecture.Domain.Common.Specifications;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion
    
    public class ProjectionQuery<TSpecification, TSource, TDest>: IQuery<TSpecification, IEnumerable<TDest>> , IQuery<TSpecification, int>
        where TSource : class, IHasId
        where TDest : class
    {
        protected readonly IQueryableDataSource DataSource;
        protected readonly IProjector Projector;

        private static readonly Type[] SpecTypes = {
            typeof(IQuerySorting<TSource>),
            typeof(IQuerySorting<TDest>),
            typeof(IQuerySpecification<TSource>),
            typeof(IQuerySpecification<TDest>),
            typeof(Expression<Func<TSource, bool>>),
            typeof(Expression<Func<TDest, bool>>),
            typeof(ExpressionSpecification<TSource>),
            typeof(ExpressionSpecification<TDest>)
        };

        private static string ErrorMessage => SpecTypes.Select(x => x.ToString()).Aggregate((c, n) => $"{c}\n{n}");

        public ProjectionQuery([NotNull] IQueryableDataSource dataSource, [NotNull] IProjector projector)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (projector == null) throw new ArgumentNullException(nameof(projector));

            DataSource = dataSource;
            Projector = projector;
        }

        protected virtual IQueryable<TDest> GetQueryable(TSpecification spec)
        {
            return DataSource
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