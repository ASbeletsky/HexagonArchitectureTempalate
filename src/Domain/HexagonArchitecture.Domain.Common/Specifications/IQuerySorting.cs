using System.Linq;

namespace HexagonArchitecture.Domain.Common.Specifications
{
    #region Using

    #endregion

    public interface IQuerySorting<T>
    {
        IOrderedQueryable<T> Apply(IQueryable<T> queryable);
    }
}