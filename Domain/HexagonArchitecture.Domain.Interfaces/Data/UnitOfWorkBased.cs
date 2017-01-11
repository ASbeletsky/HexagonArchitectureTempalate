namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using System;
    using JetBrains.Annotations;

    #endregion

    public abstract class UnitOfWorkBased
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected UnitOfWorkBased([NotNull] IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            this.UnitOfWork = unitOfWork;
        }
    }
}