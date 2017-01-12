namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using System.Linq;

    #endregion

    public interface ILinqSpecification<T>
        where T: class
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}