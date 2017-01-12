namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using System.Linq;
    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public interface IProjector
    {
        IQueryable<TReturn> Project<TSource, TReturn>(IQueryable<TSource> queryable);
    }
}