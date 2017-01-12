namespace HexagonArchitecture.Infrastructure.Interfaces.Extensions
{
    #region Using

    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Reflection;

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
    }
}