using HexagonArchitecture.Infrastructure.Interfaces.Paging;

namespace HexagonArchitecture.Services.Common.Extensions
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HexagonArchitecture.Infrastructure.Interfaces;

    #endregion

    public static class PagingExtentions
    {
        public static IPagedEnumerable<T> From<T>(IEnumerable<T> inner, int totalCount)
        {
            return new PagedEnumerable<T>(inner, totalCount);
        }

        public static IPagedEnumerable<T> Empty<T>() => From(Enumerable.Empty<T>(), 0);

        public static IOrderedQueryable<TEntity> OrderBy<TEntity, TKey>(this IQueryable<TEntity> queryable
            , Sorting<TEntity, TKey> sorting) where TEntity : class
        {
           return sorting.SortOrder == SortOrder.Asc
                ? queryable.OrderBy(sorting.Expression)
                : queryable.OrderByDescending(sorting.Expression);
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity, TKey>(this IOrderedQueryable<TEntity> queryable
            , Sorting<TEntity, TKey> sorting)
            where TEntity : class
        {
            return sorting.SortOrder == SortOrder.Asc
                ? queryable.ThenBy(sorting.Expression)
                : queryable.ThenByDescending(sorting.Expression);
        }

        public static IQueryable<T> Paginate<T, TKey>(this IQueryable<T> queryable, IPaging<T, TKey> paging) where T : class
        {
            if(!paging.OrderBy.Any())
            {
                throw new ArgumentException("OrderBy can't be null or empty", nameof(paging));
            }

            var ordered = queryable.OrderBy(paging.OrderBy[0]);
            for (int i = 1; i < paging.OrderBy.Length; i++)
            {
                ordered = ordered.ThenBy(paging.OrderBy[i]);
            }

            return ordered.Skip((paging.Page - 1) * paging.Take).Take(paging.Take);
        }

        public static IPagedEnumerable<T> ToPagedEnumerable<T, TKey>(this IQueryable<T> queryable,
            IPaging<T, TKey> paging) where T : class
        {
            return From(queryable.Paginate(paging).ToArray(), queryable.Count());
        }
    }
}