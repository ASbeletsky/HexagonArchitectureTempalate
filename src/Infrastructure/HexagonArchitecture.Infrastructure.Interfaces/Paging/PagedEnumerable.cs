using System.Collections;
using System.Collections.Generic;

namespace HexagonArchitecture.Infrastructure.Interfaces.Paging
{
    public class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        private readonly IEnumerable<T> _inner;
        private readonly int _totalCount;

        public PagedEnumerable(IEnumerable<T> inner, int totalCount)
        {
            _inner = inner;
            _totalCount = totalCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public long TotalCount => _totalCount;
    }
}