using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd;
    using System;

    #endregion

    public interface IModifiableDataSource
    {
        void AddOrUpdate<TEntity>(TEntity entity) where TEntity : class, IHasId;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IHasId;

        TEntity Find<TEntity>(object id) where TEntity : class, IHasId;

        void SaveChanges();
    }
}