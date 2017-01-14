namespace HexagonArchitecture.Services.Common.Extensions
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Linq.Dynamic.Core;
    using System.Reflection;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Services.Common.Specifications;

    #endregion

    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyDictionary<T>(this IQueryable<T> query, IDictionary<string, object> filters)
        {
            foreach (var kv in filters)
            {
                query = query.Where(kv.Value is string ? $"{kv.Key}.StartsWith(@0)" : $"{kv.Key}=@0", kv.Value);
            }
            return query;
        }

        public static IDictionary<string, object> GetFilters(this object o)
        {
            return o.GetType()
                .GetTypeInfo()
                .GetProperties(BindingFlags.Public)
                .Where(x => x.CanRead)
                .ToDictionary(k => k.Name, v => v.GetValue(o));
        }

        public static IQueryable<T> MaybeWhere<T>(this IQueryable<T> source, object spec)
            where T : class
        {
            var specification = spec as ILinqSpecification<T>;
            if (specification != null)
            {
                source = specification.Apply(source);
            }

            var expr = spec as Expression<Func<T, bool>>;
            if (expr != null)
            {
                source = source.Where(expr);
            }

            var exprSpec = spec as ExpressionSpecification<T>;
            if (exprSpec != null)
            {
                source = source.Where(exprSpec.Expression);
            }
            return source;
        }

        public static IQueryable<T> MaybeSort<T>(this IQueryable<T> source, object sort)
        {
            var srt = sort as ILinqSorting<T>;
            return srt != null ? srt.Apply(source) : source;
        }

        public static IQueryable<TDest> Project<TSource, TDest>(this IQueryable<TSource> source, IProjector projector)
        {
            return projector.Project<TSource, TDest>(source);
        }
    }
}