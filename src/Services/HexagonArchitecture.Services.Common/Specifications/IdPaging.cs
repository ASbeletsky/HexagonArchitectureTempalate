using HexagonArchitecture.Infrastructure.Interfaces;
using HexagonArchitecture.Infrastructure.Interfaces.Paging;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Services.Common.Specifications
{
    public class IdPaging<TEntity, TKey>: Paging<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public IdPaging(int page, int take)
            : base(page, take, new Sorting<TEntity, TKey>(x => x.Id, SortOrder.Desc))
        {
        }

        public IdPaging()
        {
        }

        protected override Sorting<TEntity, TKey>[] BuildDefaultSorting()
        {
            return new [] { new Sorting<TEntity, TKey>(x => x.Id, SortOrder.Desc) };
        }
    }
}