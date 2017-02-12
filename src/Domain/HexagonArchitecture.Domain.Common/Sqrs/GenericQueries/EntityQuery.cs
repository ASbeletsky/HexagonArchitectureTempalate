using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HexagonArchitecture.Domain.Common.Extensions;
using HexagonArchitecture.Domain.Interfaces.Cqrs;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;
using HexagonArchitecture.Domain.Interfaces.Paging;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Sqrs.GenericQueries
{
    public class EntityQuery<TEntity> : IEntityQuery<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IQueryableDataSource _dataSource;

        public EntityQuery([NotNull] IQueryableDataSource dataSource)
        {
            this._dataSource = dataSource;
        }


        public IEnumerable<TEntity> Where(ISpecification<TEntity> specification)
        {
            return _dataSource.Query<TEntity>()
                .MaybeWhere(specification)
                .AsEnumerable();
        }


        public IEnumerable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            return _dataSource.Include(expression);
        }

        public TEntity FirstOrDefault(ISpecification<TEntity> specification)
        {
            return this.Where(specification).FirstOrDefault();
        }

        public IPagedEnumerable<TEntity> Paged(int pageNumber, int take)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }
    }
}