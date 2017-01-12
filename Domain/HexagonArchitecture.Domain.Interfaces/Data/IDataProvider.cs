namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

    #endregion

    public interface IDataProvider
    {
        IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity;


        IQueryable Query(Type t);
    }
}