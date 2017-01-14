namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using System.Collections.Generic;
    using JetBrains.Annotations;

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