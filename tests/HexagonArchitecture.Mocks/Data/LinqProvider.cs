namespace HexagonArchitecture.Mocks.Data
{
    #region Using

     using System;
     using System.Collections.Generic;
     using System.Linq;
     using HexagonArchitecture.Domain.Interfaces.Data;
     using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

     #endregion

    public class LinqProvider : ILinqProvider
    {
        private readonly ICollection<IEntity<int>> _entities;

        public LinqProvider(ICollection<IEntity<int>> entities)
        {
            _entities = entities;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return (IQueryable<TEntity>) this._entities.AsQueryable();
        }

        public IQueryable Query(Type t)
        {
            return this._entities.AsQueryable();
        }
    }
}