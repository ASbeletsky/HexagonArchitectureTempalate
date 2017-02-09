using System.Linq;

namespace HexagonArchitecture.Domain.Common.Specifications
{
    #region Using

    #endregion

    public interface IQuerySpecification<T> where T: class
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}