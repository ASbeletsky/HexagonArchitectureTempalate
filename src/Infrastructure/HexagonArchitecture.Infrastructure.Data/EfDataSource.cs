namespace HexagonArchitecture.Infrastructure.Data
{
    #region Using

    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public class EfDataSource : IQueryableDataSource, IModifiableDataSource
    {
        private readonly DbContext _context;

        public EfDataSource()
            : this(ServiceProvider.Current.GetService<BlogsDbContext>())
        {
        }

        public EfDataSource(DbContext context)
        {
            this._context = context;
        }

        internal DbContext Context => _context;

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IHasId
        {
            return this._context.Set<TEntity>().AsQueryable();
        }

        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (entity.IsNew)
                this._context.Set<TEntity>().Add(entity);
            else
                this._context.Entry(entity).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            bool entityExists = this._context.Set<TEntity>().Any(e => e.Id.Equals(entity.Id));
            if (entityExists)
                this._context.Set<TEntity>().Remove(entity);
        }

        public TEntity Find<TEntity>(object id) where TEntity : class, IEntity
        {
            return this._context.Find<TEntity>(id);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}