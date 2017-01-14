namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using System.Linq;

    #endregion

    public interface ILinqSorting<T>
    {
        IOrderedQueryable<T> Apply(IQueryable<T> queryable);
    }
}