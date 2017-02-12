namespace HexagonArchitecture.Domain.Common.Sqrs.GenericCommandHandlers
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using JetBrains.Annotations;

    #endregion

    public class DeleteHandler<TKey, TEntity> : DataSourceBased, IDeleteEntityCommand<TKey, TEntity> where TEntity : class, IEntity<TKey>
    {
        public DeleteHandler([NotNull] IModifiableDataSource dataSource) : base(dataSource)
        {
        }

        public void Execute(TKey id)
        {
            var entity = this.DataSource.Find<TEntity>(id);
            if (entity != null)
            {
                this.DataSource.Delete(entity);
                this.DataSource.SaveChanges();
            }
        }
    }
}