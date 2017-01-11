namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd;
    using System;

    #endregion

    public interface IUnitOfWork
    {
        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;

        TEntity Find<TEntity>(object id) where TEntity : class, IEntity;

        void Commit();
    }
}