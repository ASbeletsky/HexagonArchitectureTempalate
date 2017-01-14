using System;
using System.Linq;

namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    #endregion

    public interface ILinqProvider
    {
        IQueryable<TEntity> Query<TEntity>()  where TEntity : class;
        IQueryable Query(Type t);
    }
}