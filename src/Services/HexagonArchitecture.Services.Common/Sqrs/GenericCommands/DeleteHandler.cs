namespace HexagonArchitecture.Services.Common.Sqrs.GenericCommands
{
    #region Using

    using System;
    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using JetBrains.Annotations;

    #endregion

    public class DeleteHandler<TKey, TEntity> : DataSourceBased, ICommandHandler<TKey> where TEntity : class, IEntity<TKey>
    {
        public DeleteHandler([NotNull] IModifiableDataSource dataSource) : base(dataSource)
        {
        }

        public void Handle(TKey id)
        {
            var entity = this.DataSource.Find<TEntity>(id);
            if (entity == null)
            {
                throw new ArgumentException($"Entity {typeof(TEntity).Name} with id={id} doesn't exists");
            }

            this.DataSource.Delete(entity);
        }
    }
}