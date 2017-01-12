using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs.GenericCommands
{
    #region Using

    using System;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd;
    using JetBrains.Annotations;

    #endregion

    public class DeleteHandler<TKey, TEntity> : UnitOfWorkBased, ICommandHandler<TKey> where TEntity : class, IEntity<TKey>
    {
        public DeleteHandler([NotNull] IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Handle(TKey input)
        {
            var entity = this.UnitOfWork.Find<TEntity>(input);
            if (entity == null)
            {
                throw new ArgumentException($"Entity {typeof(TEntity).Name} with id={input} doesn't exists");
            }

            this.UnitOfWork.Delete(entity);
        }
    }
}