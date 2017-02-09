using System.Collections.Generic;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Specifications.Paging
{
    #region Using

    #endregion

    [PublicAPI]
    public interface IPagedEnumerable<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Total number of entries across all pages.
        /// </summary>
        long TotalCount { get; }
    }
}