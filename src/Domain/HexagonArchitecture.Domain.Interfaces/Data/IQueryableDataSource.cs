namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

    #endregion

    public interface IQueryableDataSource
    {
        IQueryable<TEntity> Query<TEntity>()  where TEntity : class, IHasId;
        IQueryable Query(Type t);
    }
}