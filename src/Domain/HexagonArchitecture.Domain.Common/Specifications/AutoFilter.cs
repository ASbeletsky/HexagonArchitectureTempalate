using System;
using System.Collections.Generic;
using System.Linq;
using HexagonArchitecture.Domain.Common.Extensions;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Specifications
{
    #region Using

    #endregion

    public class AutoFilter<T> : IQuerySpecification<T>
            where T: class
        {
            public IDictionary<string, object> Filter { get; }

            public AutoFilter()
            {
                Filter = new Dictionary<string, object>();
            }

            public AutoFilter([NotNull] IDictionary<string, object> filter)
            {
                if (filter == null) throw new ArgumentNullException(nameof(filter));
                Filter = filter;
            }

            public IQueryable<T> Apply(IQueryable<T> query) => query.ApplyDictionary(Filter);
        }
}