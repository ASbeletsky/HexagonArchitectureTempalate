namespace HexagonArchitecture.Services.Common.Sqrs.GenericQueries
{
    #region Using

    using System.Collections.Generic;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Services.Common.Paging;

    #endregion

    public class PagedQuery<TSortKey, TSpec, TEntity, TDto> : ProjectionQuery<TSpec, TEntity, TDto>,
        IQuery<TSpec, IPagedEnumerable<TDto>>
        where TEntity : class, IHasId
        where TDto : class
        where TSpec : IPaging<TDto, TSortKey>
    {
        public PagedQuery(IQueryableDataSource dataSource, IProjector projector)
            : base(dataSource, projector)
        {
        }

        public override IEnumerable<TDto> Ask(TSpec spec) => GetQueryable(spec).Paginate(spec).ToArray();

        IPagedEnumerable<TDto> IQuery<TSpec, IPagedEnumerable<TDto>>.Ask(TSpec spec) => GetQueryable(spec).ToPagedEnumerable(spec);

        public IQuery<TSpec, IPagedEnumerable<TDto>> AsPaged() => this as IQuery<TSpec, IPagedEnumerable<TDto>>;
    }
}