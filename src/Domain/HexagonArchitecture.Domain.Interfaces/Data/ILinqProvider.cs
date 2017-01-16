namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

    #endregion

    public interface ILinqProvider

    {
        IQueryable<TEntity> Query<TEntity>()  where TEntity : class, IEntity;
        IQueryable Query(Type t);
    }
}